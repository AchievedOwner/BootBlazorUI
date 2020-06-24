using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示下拉菜单的纯文本选项。
    /// </summary>
    public class BootDropDownTextItem : BootDropDownItemBase
    {
        /// <summary>
        /// 设置任意内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 构造 span 元素的组件。
        /// </summary>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "span");
            AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 css。
        /// </summary>
        /// <param name="collection">css 集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("dropdown-item-text");
        }
    }
}
