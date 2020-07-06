using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Layout
{
    /// <summary>
    /// 呈现 div 元素，表示为1个栅格的列。
    /// </summary>
    public class BootGridColumn : BootChildComponentBase<BootGridRow>,IHasViewPoints<int>
    {
        /// <summary>
        /// 设置所有视窗的列的占比。值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-")][NullCssClass("col")] public int? Column { get; set; }
        /// <summary>
        /// 设置适配小尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter][CssClass("col-sm-")]public int? Small { get; set; }
        /// <summary>
        /// 设置适配中等尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-md-")] public int? Medium { get; set; }
        /// <summary>
        /// 设置适配大尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-lg-")] public int? Large { get; set; }
        /// <summary>
        /// 设置适配超大尺寸视窗的列的占比，值的范围是1-12。
        /// </summary>
        [Parameter] [CssClass("col-xl-")] public int? ExtraLarge { get; set; }
    }   
}
