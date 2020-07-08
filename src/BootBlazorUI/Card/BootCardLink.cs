using System.Collections.Generic;

namespace BootBlazorUI
{
    using Abstractions;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    /// <summary>
    /// 呈现卡片布局中的超链接元素。
    /// </summary>
    /// <seealso cref="BootChildComponentBase{BootCard}" />
    public class BootCardLink : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 初始化 <see cref="BootCardTitle"/> 类的新实例。
        /// </summary>
        public BootCardLink()
        {

        }

        /// <summary>
        /// 设置呈现元素的名称。默认是 h4。
        /// </summary>
        public override string ElementName { get; set; } = "a";

        /// <summary>
        /// 设置 a 元素中的 href 超链接地址。
        /// </summary>
        [Parameter]public string Link { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card-link");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, ElementName);
            AddCommonAttributes(builder);
            builder.AddAttribute(1, "href", Link);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
