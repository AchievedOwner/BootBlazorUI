
using System.Collections.Generic;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Layout
{
    /// <summary>
    /// 呈现 div 元素表示栅格的行。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootParentComponentBase{BootGridRow}" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasChildContent" />
    public class BootGridRow : BootParentComponentBase<BootGridRow>, IHasChildContent
    {
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("row");
        }
    }
}
