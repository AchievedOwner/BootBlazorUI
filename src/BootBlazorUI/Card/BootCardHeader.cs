using System;
using System.Collections.Generic;
using System.Text;

using BootBlazorUI.Abstractions;

namespace BootBlazorUI
{
    using Abstractions;
    /// <summary>
    /// 呈现卡片布局的头部元素。
    /// </summary>
    public class BootCardHeader : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 设置呈现元素的名称。
        /// </summary>
        public override string ElementName { get; set; } = "div";

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card-header");
        }
    }
}
