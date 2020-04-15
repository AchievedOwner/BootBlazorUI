using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现可旋转的容器元素。一般用于表示操作正在进行中的状态。
    /// </summary>
    public class BootSpinner : BootComponentBase
    {
        /// <summary>
        /// 设置一个布尔值，表示是否使用 Grow 样式。
        /// <para>
        /// 样式为从内到外进行填充的圆圈。
        /// </para>
        /// </summary>
        [Parameter]
        public bool Grow { get; set; }
        /// <summary>
        /// 设置旋转容器的主题颜色。
        /// </summary>
        [Parameter]
        public Color? Color { get; set; }

        /// <summary>
        /// 设置旋转容器的尺寸。
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Default;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddAttribute(2, "role", "status");
            builder.AddContent(3, content => content.AddMarkupContent(4, "<span class=\"sr-only\">加载中...</span>"));
            builder.CloseElement();
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            var spinnerClass = Grow ? "grow" : "border";
            collection.Add($"spinner-{spinnerClass}");

            if (Color.HasValue)
            {
                collection.Add(ComponentUtil.GetColorCssClass(Color.Value, "text-"));
            }

            if (Size != Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, $"spinner-{spinnerClass}-"));
            }
        }
    }
}
