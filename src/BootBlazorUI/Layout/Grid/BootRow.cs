
using System.Collections.Generic;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 div 元素表示栅格的行。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootParentComponentBase{BootGridRow}" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasChildContent" />
    public class BootRow : BootParentComponentBase<BootRow>, IHasChildContent
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
