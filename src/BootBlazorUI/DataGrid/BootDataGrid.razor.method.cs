using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootBlazorUI.DataGrid
{
    partial class BootDataGrid
    {
        /// <summary>
        /// 加载 <see cref="DataSourceProvider"/> 绑定方法的数据。
        /// </summary>
        public async Task LoadData()
        {
            ShowLoading();

            var dataSource = await Task.Run(() => DataSourceProvider());
            if(!(dataSource is IEnumerable data))
            {
                throw new InvalidOperationException($"{nameof(DataSourceProvider)} 返回的对象不是 {nameof(IEnumerable)} 的实例");
            }
            await OnDataLoading.InvokeAsync(null);
            Data = data.Cast<object>().ToList();
            await OnDataLoaded.InvokeAsync(Data);

            HideLoading();

            InitializeRowCss();
        }

        /// <summary>
        /// 点击指定的行。
        /// <para>
        /// 若指定的索引是 -1，则：
        /// <list type="bullet">
        /// <item>
        /// 若设置了 <see cref="RowSelectedColor"/> 参数，将取消所有的选中背景。
        /// </item>
        /// <item>
        /// <see cref="BootDataGridRowSelectedEventArgs.Item"/> 的值是 null。
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="index">点击行的索引。</param>
        /// <exception cref="InvalidOperationException">索引超出数组范围。</exception>
        public async Task ClickRow(int index)
        {
            if (index > Data.Count)
            {
                throw new ArgumentOutOfRangeException($"指定的索引({index})超出数组范围({Data.Count})");
            }

            await OnRowSelected.InvokeAsync(new BootDataGridRowSelectedEventArgs(index, index < 0 ? null : Data[index]));

            if (RowSelectedColor.HasValue)
            {
                var bgColorCss = ComponentUtil.GetColorCssClass(RowSelectedColor.Value, "bg-");
                var textColorCss = ComponentUtil.GetReverseColorCssClass(RowSelectedColor.Value, "text-");

                //先清空相应的 css
                if (index < 0)
                {
                    for (int i = 0; i < RowCssList.Count; i++)
                    {
                        RemoveRowCss(i, bgColorCss);
                        RemoveRowCss(i, textColorCss);
                    }
                    return;
                }

                if (!RowMultipleSelect)
                {
                    //如果不能多选行，则点击任意一行则会取消其他行的高亮。
                    for (int i = 0; i < RowCssList.Count; i++)
                    {
                        RemoveRowCss(i, bgColorCss);
                        RemoveRowCss(i, textColorCss);
                    }
                }

                if (index > -1)
                {
                    if (HasRowCss(index, bgColorCss))
                    {
                        RemoveRowCss(index, bgColorCss);
                        RemoveRowCss(index, textColorCss);
                    }
                    else
                    {
                        AddRowCss(index, bgColorCss);
                        AddRowCss(index, textColorCss);
                    }
                }
            }
        }

        /// <summary>
        /// 向指定行添加指定的 css 类的名称。如果名称已存在，则不会添加。
        /// </summary>
        /// <param name="index">指定的行索引。</param>
        /// <param name="name">css 类名称。</param>
        public void AddRowCss(int index, string name)
        {
            if (!RowCssList.ContainsKey(index))
            {
                RowCssList.Add(index, new List<string> { name });
                return;
            }

            var cssClass = RowCssList[index];
            if (!cssClass.Contains(name))
            {
                cssClass.Add(name);
            }
        }

        /// <summary>
        /// 移除指定行的 css 类名称并返回是否移除成功。
        /// </summary>
        /// <param name="index">要移除行的索引。</param>
        /// <param name="name">要移除的行的 css 类名称。</param>
        /// <returns>若指定的索引不存在或无法移除指定的 css 名称，则返回 <c>false</c>；否则返回 <c>true</c>。</returns>
        public bool RemoveRowCss(int index,string name)
        {
            if (!RowCssList.ContainsKey(index))
            {
                return false;
            }

            return RowCssList[index].Remove(name);
        }

        /// <summary>
        /// 判断指定行是否包含指定的 css 类名称。
        /// </summary>
        /// <param name="index">要判断的行索引。</param>
        /// <param name="name">要判断的行的 css 类名称。</param>
        /// <returns>若索引不存在或指定的 css 名称不存在，则返回 <c>false</c>；否则返回 <c>true</c>。</returns>
        public bool HasRowCss(int index, string name)
        {
            if (!RowCssList.ContainsKey(index))
            {
                return false;
            }
            var cssClass = RowCssList[index];

            return cssClass.Contains(name);
        }

        /// <summary>
        /// 显示数据加载中的遮罩层。
        /// </summary>
        public void ShowLoading() => IsCompleted = false;
        /// <summary>
        /// 隐藏数据加载中的遮罩层。
        /// </summary>
        public void HideLoading() => IsCompleted = true;
    }
}
