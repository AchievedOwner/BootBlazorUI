using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    using Abstractions;

    using YoiBlazor;

    /// <summary>
    /// 呈现卡片布局中的标题元素。
    /// </summary>
    /// <seealso cref="BootChildComponentBase{BootCard}" />
    public class BootCardTitle : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 初始化 <see cref="BootCardTitle"/> 类的新实例。
        /// </summary>
        public BootCardTitle()
        {

        }

        /// <summary>
        /// 设置呈现元素的名称。默认是 h4。
        /// </summary>
        public override string ElementName { get; set; } = "h4";

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card-title");
        }
    }
}
