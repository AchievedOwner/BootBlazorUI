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
            IsCompleted = false;
            var dataSource= DataSourceProvider.Invoke();
            if(!(dataSource is IEnumerable data))
            {
                throw new InvalidOperationException($"{nameof(DataSourceProvider)} 返回的对象不是 {nameof(IEnumerable)} 的实例");
            }
            await OnDataLoading.InvokeAsync(null);
            Data = data.Cast<object>().ToList();
            await OnDataLoaded.InvokeAsync(Data);
            IsCompleted = true;
        }

        /// <summary>
        /// 点击指定的行。
        /// </summary>
        /// <param name="item">被选择的行数据。</param>
        /// <param name="index">选择行的索引。</param>
        public async Task ClickRow(object item, int index)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (index < 0)
            {
                throw new ArgumentException($"选择行的索引必须大于0，但实际的值是'{index}'", nameof(index));
            }

            await OnRowSelected.InvokeAsync(new BootDataGridRowSelectedEventArgs(item, index));

            if (RowSelectedColor.HasValue)
            {
                var bgColorCss = ComponentUtil.GetColorCssClass(RowSelectedColor.Value, "bg-");
                var textColorCss =ComponentUtil.GetReverseColorCssClass(RowSelectedColor.Value,"text-");

                if (!RowMultipleSelect)
                {
                    //如果不能多选行，则点击任意一行则会取消其他行的高亮。
                    for (int i = 0; i < RowCssList.Count; i++)
                    {
                        RemoveRowCss(i, bgColorCss);
                        RemoveRowCss(i, textColorCss);
                    }
                }

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

        /// <summary>
        /// 向指定行添加指定的 css 类。如果类名称已存在，则不会添加。
        /// </summary>
        /// <param name="index">指定的行索引。</param>
        /// <param name="name">css 类名称。</param>
        /// <returns>若成功添加，则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool AddRowCss(int index, string name)
        {
            if (HasRowCss(index, name))
            {
                return false;
            }
            var cssList = RowCssList[index];
            if (!cssList.Contains(name))
            {
                cssList.Add(name);
                return true;
            }
            return false;
        }

        public bool RemoveRowCss(int index,string name)
        {
            if (!RowCssList.ContainsKey(index))
            {
                return false;
            }

            var cssList = RowCssList[index];
            if (cssList == null)
            {
                cssList = new List<string>();
            }
            return cssList.Remove(name);
        }

        public bool HasRowCss(int index,string name)
        {
            if (!RowCssList.ContainsKey(index))
            {
                return false;
            }
            var cssList = RowCssList[index];
            if (cssList == null)
            {
                cssList = new List<string>();
            }

            return cssList.Contains(name);
        }

        /// <summary>
        /// 向指定行追加指定的 style 自定义样式。
        /// </summary>
        /// <param name="index">指定的行索引。</param>
        /// <param name="styles">样式数组。</param>
        public void AppendRowStyle(int index, params string[] styles)
        {
            if (styles is null)
            {
                throw new ArgumentNullException(nameof(styles));
            }

            if (!RowCssList.ContainsKey(index))
            {
                RowCssList.Add(index, new List<string>(styles));
            }
            else
            {
                RowCssList[index].AddRange(styles);
            }
        }
    }
}
