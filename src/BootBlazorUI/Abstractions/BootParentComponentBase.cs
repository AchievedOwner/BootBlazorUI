using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 表示嵌套组件的父组件的基类。这是一个抽象类。
    /// </summary>
    /// <typeparam name="TParentComponent">父组件类型。</typeparam>
    public abstract class BootParentComponentBase<TParentComponent>:BootComponentBase,IHasChildContent
        where TParentComponent: IComponent
    {
        /// <summary>
        /// 设置 <typeparamref name="TParentComponent"/> 组件的内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 用于存储子组件的列表。
        /// </summary>
        private readonly List<IComponent> _childComponents = new List<IComponent>();

        /// <summary>
        /// 获取该父组件包含的子组件列表。
        /// </summary>
        public IReadOnlyList<IComponent> ChildComponents => _childComponents;

        /// <summary>
        /// 获取元素的名称。默认是 div。
        /// </summary>
        protected virtual string ElementName => "div";

        /// <summary>
        /// 使用 <see cref="RenderTreeBuilder"/> 创建父组件的 <see cref="CascadingValue{TComponent}"/> 组件。
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, ElementName);
            AddCommonAttributes(builder);
            builder.OpenComponent<CascadingValue<TParentComponent>>(100);
            builder.AddAttribute(101, "Value", this);
            builder.AddAttribute(102, nameof(ChildContent), ChildContent);
            builder.CloseComponent();

            builder.CloseElement();
        }

        /// <summary>
        /// 添加指定的子组件。
        /// </summary>
        /// <param name="component">子组件。</param>
        public void Add(IComponent component) => _childComponents.Add(component);
    }
}
