using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示下拉框选项使用 a 元素呈现。
    /// </summary>
    public class BootDropDownLinkItem : BootDropDownItemBase
    {
        /// <summary>
        /// 设置选项的内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置超链接。
        /// </summary>
        [Parameter] public string Link { get; set; } = "javascript:;";

        /// <summary>
        /// 构造 <see cref="NavLink"/> 组件组成的下拉菜单选项。
        /// </summary>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<NavLink>(0);
            builder.AddAttribute(1, "Match", NavLinkMatch.All);
            builder.AddAttribute(2, "href", Link);
            base.AddCommonAttributes(builder);
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, () => Parent.Toggle()));
            builder.AddAttribute(3, nameof(ChildContent),ChildContent);
            builder.CloseComponent();
        }

        /// <summary>
        /// 构造组件的样式。
        /// </summary>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("dropdown-item");
        }
    }

}
