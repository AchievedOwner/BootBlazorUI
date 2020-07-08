using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    using Abstractions;
    /// <summary>
    /// 表示将一系列按钮与按钮组分组在同一行上。
    /// </summary>
    public class BootButtonGroup : BootComponentBase
    {
        /// <summary>
        /// 设置按钮组的内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置按钮组的尺寸。
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置一个布尔值，表示是否垂直显示。
        /// </summary>
        [Parameter] public bool Vertical { get; set; }

        /// <summary>
        /// 构建按钮组的组件树。
        /// </summary>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddAttribute(1, "role", "group");
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 css Class。
        /// </summary>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if(Size!= Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, "btn-group-"));
            }

            if (Vertical)
            {
                collection.Add("btn-group-vertical");
            }
            else
            {
                collection.Add("btn-group");
            }
        }
    }
}
