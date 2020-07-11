using System.Collections.Generic;

using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    using Abstractions;

    using Microsoft.AspNetCore.Components;

    using YoiBlazor;

    /// <summary>
    /// 呈现 div 元素以表示卡片的正文内容。
    /// </summary>
    public class BootCardBody : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 设置一个布尔值，表示正文部分会被叠加到 <see cref="BootCardImage"/> 组件上。
        /// </summary>
        /// <value>
        ///   如果要叠加在 <see cref="BootCardImage"/> 组件上，则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter][CssClass("card-img-overlay")][FalseCssClass("card-body")] public bool? Overlay { get; set; }

        /// <summary>
        /// 设置呈现元素的名称。默认是 div。
        /// </summary>
        public override string ElementName { get; set; } = "div";

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card-body");

            if (Parent.Color.HasValue && Parent.Border.HasValue)
            {
                collection.Add(ComponentUtil.GetColorCssClass(Parent.Color.Value, "text-"));
            }
        }
    }
}
