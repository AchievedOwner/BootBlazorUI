using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现一个将 <see cref="EditContext"/> 级联到后代的表单元素。可配合 <see cref="BootButton"/> 组件提升提交时的交互性。
    /// </summary>
    public class BootEditForm : BootComponentBase
    {
        private EditContext _fixedEditContext;

        /// <summary>
        /// 初始化 <see cref="BootEditForm"/> 类的新实例。
        /// </summary>
        public BootEditForm()
        {

        }

        /// <summary>
        /// 指定最上层的表单模型绑定对象。一个新的 <see cref="EditContext"/> 对象将被该模型构造。若设置了该属性，则不需要再设置 <see cref="EditContext"/> 属性。
        /// </summary>
        [Parameter]
        public object Model { get; set; }

        /// <summary>
        /// 显式地提供表单编辑上下文，若设置了 <see cref="Model"/> 的值，则不要再设置 <see cref="EditContext"/> 属性。
        /// 然后该值将取代 <see cref="EditContext.Model"/> 的属性。
        /// </summary>
        [Parameter]
        public EditContext EditContext { get; set; }

        /// <summary>
        /// 设置表单内呈现的内容。
        /// </summary>
        [Parameter]
        public RenderFragment<EditContext> ChildContent { get; set; }

        /// <summary>
        /// 当 <see cref="BootEditForm"/> 参数设置之后。
        /// </summary>
        protected override void OnParametersSet()
        {
            if ((EditContext == null) == (Model == null))
            {
                throw new InvalidOperationException($"{nameof(BootEditForm)} 要求一个 {nameof(Model)} " +
                    $"参数，或者一个 {nameof(EditContext)} 参数，但不能两者都有。");
            }

            // Update _fixedEditContext if we don't have one yet, or if they are supplying a
            // potentially new EditContext, or if they are supplying a different Model
            if (_fixedEditContext == null || EditContext != null || Model != _fixedEditContext.Model)
            {
                _fixedEditContext = EditContext ?? new EditContext(Model);
            }
        }

        /// <summary>
        /// 构造表单内容。
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenRegion(_fixedEditContext.GetHashCode());

            builder.OpenElement(0, "form");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.OpenComponent<CascadingValue<EditContext>>(2);
            builder.AddAttribute(3, "Value", _fixedEditContext);
            builder.AddAttribute(4, "IsFixed", true);
            builder.AddAttribute(5, nameof(ChildContent), ChildContent?.Invoke(_fixedEditContext));
            builder.CloseComponent();
            builder.CloseElement();

            builder.CloseRegion();
        }
    }
}
