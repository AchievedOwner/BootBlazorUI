using System;
using System.Collections.Generic;
using System.Text;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 div 元素的块状引用组件。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootComponentBase" />
    [Element("blockquote")]
    public class BlockQuote : BootComponentBase, IHasChildContent
    {
        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("blockquote");
        }
    }
}
