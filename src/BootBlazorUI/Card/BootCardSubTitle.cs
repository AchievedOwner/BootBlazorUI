using System.Collections.Generic;

namespace BootBlazorUI
{
    using Abstractions;
    /// <summary>
    /// 呈现卡片布局中的比标题小一号的副标题元素。
    /// </summary>
    /// <seealso cref="BootChildComponentBase{BootCard}" />
    public class BootCardSubTitle : BootChildComponentBase<BootCard>
    {
        /// <summary>
        /// 初始化 <see cref="BootCardSubTitle"/> 类的新实例。
        /// </summary>
        public BootCardSubTitle()
        {

        }

        /// <summary>
        /// 设置呈现元素的名称。默认是 h6。
        /// </summary>
        public override string ElementName { get; set; } = "h6";

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card-subtitle");
        }
    }
}
