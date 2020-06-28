using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示下拉菜单选项的模板。
    /// </summary>
    public class BootDropDownTemplate : BootDropDownItemBase
    {
        /// <summary>
        /// 设置任意内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 构造组件。
        /// </summary>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, ChildContent);
        }
    }
}
