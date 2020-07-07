using System.Collections.Generic;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示使用 div 元素呈现的栅格系统的容器组件。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootComponentBase" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasChildContent" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasViewPoint" />
    public class BootContainer : BootComponentBase, IHasChildContent,IHasViewPoint
    {
        /// <summary>
        /// 样式名称。
        /// </summary>
        const string CLASS_NAME = "container";

        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示使用一个全宽度的容器，跨越视窗的整个宽度。
        /// </summary>
        [Parameter] public bool Fluid { get; set; }
        /// <summary>
        /// 设置浏览器适配的数组，<c>null</c> 使用默认值。
        /// </summary>
        /// <remarks>
        /// 若设置了该参数，则 <see cref="Fluid"/> 无效。
        /// </remarks>
        /// <value>
        ///   <see cref="ViewPoint" /> 枚举数组或 <c>null</c>。
        /// </value>
        [Parameter][CssClass(CLASS_NAME)]public ViewPoint? ViewPoint { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if (ViewPoint.HasValue && ViewPoint.Value > BootBlazorUI.ViewPoint.ExtraSmall)
            {
                collection.Add(ViewPoint.GetEnumCssClass(this,nameof(ViewPoint)));
            }
            else
            {
                collection.Add($"{CLASS_NAME}{(Fluid ? "-fluid" : null)}");
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }
    }
}
