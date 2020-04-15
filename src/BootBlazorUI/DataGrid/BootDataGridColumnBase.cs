using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 表示 DataGrid 列的基类，这是一个抽象类。
    /// </summary>
    public abstract class BootDataGridColumnBase:BootComponentBase
    {
        /// <summary>
        /// 设置列的标题。
        /// </summary>
        [Parameter]
        public string Title { get; set; }


        /// <summary>
        /// 设置单元格的宽度。不设置则自动计算宽度。
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
        /// <returns></returns>
        internal string GetWidthStyleString()
            => !string.IsNullOrWhiteSpace(Width) ? $"width:{Width}" : $"width:{Parent.GetAutoColumnWidth()}%";


        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentException($"{nameof(BootDataGridFieldColumn)} 只能在 {nameof(BootDataGrid)} 中使用");
            }
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {

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
