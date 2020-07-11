
namespace BootBlazorUI
{
    using System.Collections.Generic;

    using Abstractions;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    using YoiBlazor;

    /// <summary>
    /// 呈现卡片组件中的顶部图片元素。
    /// </summary>
    /// <seealso cref="BootChildComponentBase{BootCard}" />
    public class BootCardImage : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 设置呈现元素的名称。
        /// </summary>
        public override string ElementName { get; set; } = "img";

        /// <summary>
        /// 设置 img 元素的 src 图片来源。
        /// </summary>
        [Parameter]public string Source { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示图片作为的底层元素被 <see cref="BootCardBody"/> 组件叠加在上面。
        /// </summary>
        /// <remarks>
        /// 当 <see cref="BootCardBody.Overlay"/> 时 <c>true</c> 时有效。
        /// </remarks>
        /// <value>
        ///   如果被叠加，则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] public bool Overlay { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, ElementName);
            AddCommonAttributes(builder);
            builder.AddAttribute(1, "src", Source);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if (Overlay)
            {
                collection.Add("card-img");
            }
            else
            {
                collection.Add("card-img-top");
            }
        }
    }
}
