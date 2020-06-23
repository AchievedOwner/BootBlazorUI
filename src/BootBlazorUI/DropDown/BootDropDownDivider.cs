using System.Collections.Generic;

using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示下拉菜单选项是一个分割线。
    /// </summary>
    public class BootDropDownDivider : BootDropDownItemBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.CloseElement();
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("dropdown-divider");
        }
    }
}
