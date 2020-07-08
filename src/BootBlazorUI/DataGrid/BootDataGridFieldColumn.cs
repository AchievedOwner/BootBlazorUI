using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 可对 <see cref="BootDataGrid"/> 进行数据绑定的列。
    /// </summary>
    public class BootDataGridFieldColumn : BootDataGridColumnBase
    {
        /// <summary>
        /// 设置数据源绑定的字段。
        /// </summary>
        [Parameter]
        public string Field { get; set; }

        /// <summary>
        /// 设置绑定字段的显示格式。
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// 没有设置要绑定的 {Field} 字段
        /// </exception>
        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentException($"{nameof(BootDataGridFieldColumn)} 只能在 {nameof(BootDataGrid)} 中使用");
            }

            if (string.IsNullOrWhiteSpace(Field))
            {
                throw new ArgumentException($"没有设置要绑定的 {Field} 字段");
            }
        }

        /// <summary>
        /// 获取列标题。
        /// </summary>
        internal override string GetTitle()
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                return Title;
            }

            return Field;
        }
    }
}
