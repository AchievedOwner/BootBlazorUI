using System.Collections.Generic;

using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    using Abstractions;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// 呈现 div 元素并带有 "card" 样式的卡片组件。
    /// </summary>
    /// <seealso cref="BootComponentBase" />
    public class BootCard : BootParentComponentBase<BootCard>
    {
        /// <summary>
        /// 初始化 <see cref="BootCard"/> 类的新实例。
        /// </summary>
        public BootCard()
        {

        }

        /// <summary>
        /// 设置颜色主题方案。
        /// </summary>
        [Parameter] public Color? Color { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否使用边框的主题颜色，需要配合 <see cref="Color"/> 属性使用。
        /// </summary>
        [Parameter] public bool Bordered { get; set; }

        /// <summary>
        /// 设置一个布尔值，卡片的高度是否为 100%。该属性用于在栅格系统布局中将其他卡片对齐高度。
        /// </summary>
        [Parameter] public bool AlignHeight { get; set; }

        ///// <summary>
        ///// 使用 <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> 创建父组件的 <see cref="T:Microsoft.AspNetCore.Components.CascadingValue`1" /> 组件。
        ///// </summary>
        ///// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    builder.OpenElement(0, "div");
        //    AddCommonAttributes(builder);
        //    base.BuildRenderTree(builder);
        //    builder.CloseElement();
        //}

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("card");
            if (Color.HasValue)
            {
                if (Bordered)
                {
                    collection.Add(ComponentUtil.GetColorCssClass(Color.Value, "border-"));
                }
                else
                {
                    collection.Add(ComponentUtil.GetColorCssClass(Color.Value, "bg-"));
                    collection.Add(ComponentUtil.GetReverseColorCssClass(Color.Value, "text-"));
                }
            }

            if (AlignHeight)
            {
                collection.Add("h-100");
            }
        }
    }
}
