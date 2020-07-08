
using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 div 元素的组件。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootComponentBase" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasChildContent" />
    [Element]
    public class Div : BootComponentBase, IHasChildContent
    {
        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }
    }
}
