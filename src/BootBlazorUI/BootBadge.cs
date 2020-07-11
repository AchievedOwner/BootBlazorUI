using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    using Abstractions;

    using YoiBlazor;

    /// <summary>
    /// 呈现 span 元素的徽章组件，可以醒目并优雅地呈现一些状态或醒目的文字。
    /// </summary>
    [ElementTag("span")]
    public class BootBadge : BootComponentBase,IHasChildContent
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
        [CssClass("badge-")]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// 设置一个布尔值，表示是否使用药丸样式。
        /// </summary>
        [Parameter]
        [CssClass("badge-pill")]
        public bool? Pill { get; set; }

        /// <summary>
        /// 设置徽章的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("badge");
        }
    }
}
