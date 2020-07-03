using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示使用 ol 元素当前页面在自动添加分隔符的导航层次结构中的位置。
    /// </summary>
    public class BootBreadCrumb : BootComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BootBreadCrumb"/> 类的新实例。
        /// </summary>
        public BootBreadCrumb()
        {

        }

        /// <summary>
        /// 设置 <see cref="BootBreadCrumbItem"/> 导航元素。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 获取面包屑导航的项列表。
        /// </summary>
        List<BootBreadCrumbItem> Items { get; set; } = new List<BootBreadCrumbItem>();

        /// <summary>
        /// 构造组件。
        /// </summary>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "nav");
            builder.OpenElement(1, "ol");
            AddCommonAttributes(builder);

            builder.OpenComponent<CascadingValue<BootBreadCrumb>>(2);
            builder.AddAttribute(3, "Value", this);
            builder.AddAttribute(4, nameof(ChildContent), ChildContent);
            builder.CloseComponent();

            builder.CloseElement();
            builder.CloseElement();
        }
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("breadcrumb");
        }

        /// <summary>
        /// 添加面包屑导航的项。
        /// </summary>
        /// <param name="item">要添加的项。</param>
        public void Add(BootBreadCrumbItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Items.Add(item);
        }
    }
}
