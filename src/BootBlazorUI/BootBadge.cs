using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 span 元素的徽章组件，可以醒目并优雅地呈现一些状态或醒目的文字。
    /// </summary>
    public class BootBadge : BootComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BootBadge"/> 类的新实例。
        /// </summary>
        public BootBadge()
        {

        }

        /// <summary>
        /// 设置徽章的颜色主题。默认是是 <see cref="Color.Primary"/> 主题。
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// 设置一个布尔值，表示是否使用药丸样式。
        /// </summary>
        [Parameter]
        public bool Pill { get; set; }

        /// <summary>
        /// 设置徽章的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 构造 BootBadge 组件。
        /// </summary>
        /// <param name="builder">渲染构造器。</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "span");
            AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// 构造组件所需 class 类。
        /// </summary>
        /// <param name="collection"></param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("badge");
            collection.Add(ComponentUtil.GetColorCssClass(Color, "badge-"));

            if (Pill)
            {
                collection.Add("badge-pill");
            }
        }
    }
}
