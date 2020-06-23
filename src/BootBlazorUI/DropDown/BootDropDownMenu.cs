using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示下拉菜单。
    /// </summary>
    public class BootDropDownMenu:BootActivableComponentBase
    {
        public BootDropDownMenu()
        {
            base.ActivedCssClass = "show";
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置下拉菜单选项展开的方向。默认 <see cref="Direction.Down"/>。
        /// </summary>
        public Direction DropDirection { get; set; } = Direction.Down;//暂未实现

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            base.CreateComponentCssClass(collection);
            collection.Add("dropdown-menu");
        }

        protected override void CreateComponentStyle(ICollection<string> collection)
        {
            if (IsActived)
            {
                collection.Add($"position: absolute; transform: translate3d(0px, 56px, 0px); top: 0px; left: 0px; will-change: transform;");
            }
        }

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
            builder.AddAttribute(4, nameof(ChildContent),ChildContent);
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
