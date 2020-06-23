using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    public class BootDropDownTextItem : BootDropDownItemBase
    {
        [Parameter]public RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "span");
            AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("dropdown-item-text");
        }
    }
}
