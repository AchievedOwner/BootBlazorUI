
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Abstractions
{

    /// <summary>
    /// 表示嵌套组件的子组件的基类。这是一个抽象类。
    /// </summary>
    /// <typeparam name="TParentComponent">父组件的类型。</typeparam>
    /// <seealso cref="BootBlazorUI.Abstractions.BootComponentBase" />
    public abstract class BootChildComponentBase<TParentComponent> : BootComponentBase,IHasChildContent
        where TParentComponent : BootParentComponentBase<TParentComponent>
    {
        /// <summary>
        /// 获取级联的父组件。
        /// </summary>
        [CascadingParameter]protected virtual TParentComponent Parent { get; set; }

        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置呈现元素的名称。
        /// </summary>
        [Parameter] public virtual string ElementName { get; set; } = "div";

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="BootChildNotInParentComponentException"></exception>
        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new BootChildNotInParentComponentException(typeof(TParentComponent), this.GetType());
            }

            base.OnInitialized();
            Parent.Add(this);
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, ElementName);
            AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }
    }
}
