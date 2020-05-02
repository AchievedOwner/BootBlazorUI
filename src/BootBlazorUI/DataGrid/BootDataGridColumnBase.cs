using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 表示 DataGrid 列的基类，这是一个抽象类。
    /// </summary>
    public abstract class BootDataGridColumnBase : BootComponentBase
    {
        /// <summary>
        /// 设置列的标题。
        /// </summary>
        [Parameter]
        public string Title { get; set; }


        /// <summary>
        /// 设置单元格的宽度，单位自己决定。如果所有的列都不设置宽度，则会平均分配。
        /// </summary>
        [Parameter]
        public string Width { get; set; }

        /// <summary>
        /// 设置列的对齐方式。
        /// </summary>
        [Parameter]
        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Center;

        /// <summary>
        /// 父组件。
        /// </summary>
        [CascadingParameter]
        internal BootDataGrid Parent { get; set; }



        /// <summary>
        /// 获取列的宽度 style 字符串，即 width:xxx
        /// </summary>
        internal string GetWidthStyleString()
        {
            if (!string.IsNullOrWhiteSpace(Width))
            {
                return $"width:{Width}";
            }
            var columnsHasWidthCount = Parent.Columns.Count(m => string.IsNullOrWhiteSpace(m.Width));
            if (columnsHasWidthCount == Parent.Columns.Count)
            {
                return $"width:calc(100%/{columnsHasWidthCount})";
            }
            return null;
        }


        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentException($"{nameof(BootDataGridFieldColumn)} 只能在 {nameof(BootDataGrid)} 中使用");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Parent.AddColumn(this);
            }
        }



        /// <summary>
        /// 获取列标题。
        /// </summary>
        internal virtual string GetTitle() => Title;

    }
}
