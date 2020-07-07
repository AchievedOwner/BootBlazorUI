
using BootBlazorUI.Abstractions;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 div 元素，表示为1个栅格的列。
    /// </summary>
    public class BootColumn : BootChildComponentBase<BootRow>
    {
        /// <summary>
        /// 设置所有视窗的列的占比。值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-")][NullCssClass("col")] public int? Column { get; set; }
        /// <summary>
        /// 设置适配小尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter][CssClass("col-sm-")]public int? ColumnSmall { get; set; }
        /// <summary>
        /// 设置适配中等尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-md-")] public int? ColumnMedium { get; set; }
        /// <summary>
        /// 设置适配大尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-lg-")] public int? ColumnLarge { get; set; }
        /// <summary>
        /// 设置适配超大尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-xl-")] public int? ColumnExtraLarge { get; set; }
    }   
}
