using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 呈现可进行多功能操作的数据表格的组件。
    /// </summary>
    partial class BootDataGrid
    {
        /// <summary>
        /// 初始化 <see cref="BootDataGrid"/> 类的新实例。
        /// </summary>
        public BootDataGrid()
        {
            DataEmptyTemplate = builder =>
            {
                builder.AddMarkupContent(0, "<small class=\"text-muted\">目前为止还没有任何数据喔！</small>");
            };
        }

        #region 参数
        /// <summary>
        /// 设置一个布尔值，表示是否表格第一列使用行号。
        /// </summary>
        [Parameter] public bool RowNumber { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一行是否显示间隔颜色。
        /// </summary>
        [Parameter] public bool Striped { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一个单元格是否显示边框。
        /// </summary>
        [Parameter] public bool Bordered { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一个单元格是否不显示边框。
        /// </summary>
        [Parameter]public bool Borderless { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示表格使用深色背景显示。
        /// </summary>
        [Parameter] public bool Dark { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示行在鼠标悬浮时是否有颜色高亮。
        /// </summary>
        [Parameter] public bool Hover { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否使用紧凑行间距。
        /// </summary>
        [Parameter] public bool Small { get; set; }

        /// <summary>
        /// 设置数据表格的内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置数据行的固定高度。单位是 px。并将列头进行顶部固定。
        /// </summary>
        [Parameter] public int? RowHeight { get; set; }

        /// <summary>
        /// 设置一个实现数据加载的委托，并必须范围实现 <see cref="IEnumerable"/> 接口的数据源。
        /// </summary>
        [Parameter] public Func<object> DataSourceProvider { get; set; }

        /// <summary>
        /// 设置数据源是空时显示的内容。
        /// </summary>
        [Parameter] public RenderFragment DataEmptyTemplate { get; set; }

        /// <summary>
        /// 设置点击行后的该行的高亮颜色。若为 null 则不高亮。
        /// </summary>
        [Parameter] public Color? RowSelectedColor { get; set; }

        /// <summary>
        /// 设置一个布尔值，是否允许选择多条行。
        /// </summary>
        [Parameter] public bool RowMultipleSelect { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在渲染后自动加载数据。默认是 <c>true</c>。
        /// <para>
        /// 若设置为 <c>false</c>，则需要手动调用 <see cref="LoadData"/> 方法来加载数据。
        /// </para>
        /// </summary>
        [Parameter] public bool LoadDataAfterRender { get; set; } = true;
        #endregion

        #region 事件
        /// <summary>
        /// 设置当数据行被点击后触发选择行事件。
        /// </summary>
        [Parameter] public EventCallback<BootDataGridRowSelectedEventArgs> OnRowSelected { get; set; }

        /// <summary>
        /// 设置当数据加载前触发的事件。
        /// </summary>
        [Parameter] public EventCallback OnDataLoading { get; set; }
        /// <summary>
        /// 设置当数据加载完成后触发的事件。
        /// </summary>
        [Parameter] public EventCallback<IReadOnlyList<object>> OnDataLoaded { get; set; }
        #endregion

        /// <summary>
        /// 返回一个布尔值，表示数据是否已加载完成。
        /// </summary>
        /// <returns>若已加载完成，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public bool IsCompleted { get; private set; }

        protected override void OnInitialized()
        {
            if (DataSourceProvider == null)
            {
                throw new ArgumentException($"必须设置参数", nameof(DataSourceProvider));
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (LoadDataAfterRender)
                {
                    await LoadData();
                }
                else
                {
                    IsCompleted = true;
                }

                for (int i = 0; i < Data.Count; i++)
                {
                    RowCssList.Add(i, new List<string>());
                }
            }
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("table");

            if (Striped)
            {
                collection.Add("table-striped");
            }
            if (Bordered)
            {
                collection.Add("table-bordered");
            }
            if (Borderless)
            {
                collection.Add("table-borderless");
            }
            if (Dark)
            {
                collection.Add("table-dark");
            }
            if (Hover)
            {
                collection.Add("table-hover");
            }
            if (Small)
            {
                collection.Add("table-sm");
            }
        }
    }

   
}
