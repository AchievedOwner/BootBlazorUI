
using System.Collections.Generic;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 div 元素表示栅格的行。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootParentComponentBase{BootGridRow}" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasChildContent" />
    public class BootRow : BootParentComponentBase<BootRow>, IHasChildContent
    {
        /// <summary>
        /// 设置在任何视窗下的固定列数。值的范围是1-6。
        /// </summary>
        [Parameter][CssClass("row-cols-")]public int? Columns { get; set; }
        /// <summary>
        /// 设置在小尺寸视窗下的固定列数。值的范围是1-6。
        /// </summary>
        [Parameter] [CssClass("row-cols-sm-")] public int? ColumnsSM { get; set; }

        /// <summary>
        /// 设置在中等尺寸视窗下的固定列数。值的范围是1-6。
        /// </summary>
        [Parameter] [CssClass("row-cols-md-")] public int? ColumnsMD { get; set; }
        /// <summary>
        /// 设置在大尺寸视窗下的固定列数。值的范围是1-6。
        /// </summary>
        [Parameter] [CssClass("row-cols-lg-")] public int? ColumnsLG { get; set; }
        /// <summary>
        /// 设置在超大尺寸视窗下的固定列数。值的范围是1-6。
        /// </summary>
        [Parameter] [CssClass("row-cols-xl-")] public int? ColumnsXL { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("row");
        }
    }
}
