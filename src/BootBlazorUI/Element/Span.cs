
using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 span 元素的组件。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootComponentBase" />
    [ElementTag("span")]
    public class Span : BootComponentBase, IHasChildContent
    {
        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }
    }
}
