using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    using Abstractions;

    using BootBlazorUI.Abstractions.Parameters;

    using YoiBlazor;

    /// <summary>
    /// 表示将一系列按钮与按钮组分组在同一行上。
    /// </summary>
    [ElementTag]
    public class BootButtonGroup : BootComponentBase,IHasChildContent,IHasSize
    {
        /// <summary>
        /// 设置按钮组的内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置按钮组的尺寸。
        /// </summary>
        [Parameter][CssClass("btn-group-")] public Size? Size { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否垂直显示。
        /// </summary>
        [Parameter][CssClass("btn-group-vertical")][NullCssClass("btn-group")] public bool? Vertical { get; set; }
    }
}
