using System.Collections.Generic;

namespace BootBlazorUI
{
    using Abstractions;

    using YoiBlazor;

    /// <summary>
    /// 呈现卡片布局中的文本元素。
    /// </summary>
    /// <seealso cref="BootChildComponentBase{BootCard}" />
    public class BootCardText : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 初始化 <see cref="BootCardSubTitle"/> 类的新实例。
        /// </summary>
        public BootCardText()
        {

        }

        /// <summary>
        /// 设置呈现元素的名称。默认是 p。
        /// </summary>
        public override string ElementName { get; set; } = "p";

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card-text");
        }
    }
}
