using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    using Abstractions;
    /// <summary>
    /// 呈现一个 div 元素用于呈现下拉菜单的组件。
    /// </summary>
    public class BootDropDownMenu : BootActivableComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BootDropDownMenu"/> class.
        /// </summary>
        public BootDropDownMenu()
        {
            base.ActivedCssClass = "show";
        }
        /// <summary>
        /// Gets or sets the content of the child.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置下拉菜单选项展开的方向。默认 <see cref="Direction.Down"/>。
        /// </summary>
        public Direction DropDirection { get; set; } = Direction.Down;//暂未实现

        /// <summary>
        /// 创建组件所需要的 css。
        /// </summary>
        /// <param name="collection">css 集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            base.CreateComponentCssClass(collection);
            collection.Add("dropdown-menu");
        }
        /// <summary>
        /// 创建组件所需要的 style 样式。
        /// </summary>
        /// <param name="collection">style 名称集合。</param>
        protected override void CreateComponentStyle(ICollection<string> collection)
        {
            if (IsActived)
            {
                collection.Add($"position: absolute; transform: translate3d(0px, 56px, 0px); top: 0px; left: 0px; will-change: transform;");
            }
        }
        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);

            if (IsActived)
            {
                builder.AddAttribute(1, "x-placement", $"{GetDirectionName()}-start");
            }

            builder.OpenComponent<CascadingValue<BootDropDownMenu>>(2);
            builder.AddAttribute(3, "Value", this);
            builder.AddAttribute(4, nameof(ChildContent), ChildContent);
            builder.CloseComponent();

            builder.CloseElement();
        }

        string GetDirectionPosition()
            => DropDirection switch
            {
                Direction.Up => "bottom:0px;left:0px;",
                Direction.Right => "left:0px;",
                Direction.Left => "right:0px;",
                _ => "top:0px;left:0px;"
            };

        string GetDirectionName()
            => DropDirection switch
            {
                Direction.Up => "top",
                Direction.Right => "right",
                Direction.Left => "left",
                _ => "bottom"
            };
    }
}
