using System.Collections.Generic;

using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示下拉菜单选项是一个分割线。
    /// </summary>
    public class BootDropDownDivider : BootDropDownItemBase
    {
        /// <summary>
        /// 创建组件元素。
        /// </summary>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 css。
        /// </summary>
        /// <param name="collection">css 集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("dropdown-divider");
        }
    }
}
