using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现 type="checkbox" 的 input 元素的组件。
    /// </summary>
    public class BootInputCheckbox : BootInputBase<bool>
    {
        /// <summary>
        /// 初始化 <see cref="BootInputCheckbox"/> 类的新实例。
        /// </summary>
        public BootInputCheckbox()
        {
        }

        /// <summary>
        /// 设置跟随复选框的文本。不设置，则不显示文本。
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// 设置复选框文本的 class 名称。
        /// </summary>
        [Parameter]
        public string LabelCssClass { get; set; } = "form-check-label";
        /// <summary>
        /// 构造输入组件公共的渲染树。
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            if (!string.IsNullOrEmpty(Label))
            {
                builder.OpenElement(50, "label");
                builder.AddAttribute(51, "class", LabelCssClass);
                builder.AddAttribute(53, "for", Id);
                builder.AddContent(52, (MarkupString)Label);
                builder.CloseElement();
            }
        }
        /// <summary>
        /// 构造输入组件的渲染树。
        /// </summary>
        /// <param name="builder">渲染构造器。</param>
        /// <param name="sequence">系列。</param>
        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence, "type", "checkbox");
        }
        /// <summary>
        /// 构造值绑定的特性，默认使用 <see cref="T:Microsoft.AspNetCore.Components.BindConverter" /> 类型。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        protected override void BuildValueBindingAttribute(RenderTreeBuilder builder, int sequence)
            =>
            builder.AddAttribute(sequence++, "checked", BindConverter.FormatValue(CurrentValue));

        /// <summary>
        /// 使用 bool 类型构造复选框的改变事件。
        /// </summary>
        protected override EventCallback<ChangeEventArgs> BuildChangeEventCallback()
        => EventCallback.Factory.CreateBinder<bool>(this, value => CurrentValue = value, CurrentValue);
        /// <summary>
        /// 定义组件的元素名称。
        /// </summary>
        /// <returns>
        /// 组件元素的名称字符串。
        /// </returns>
        protected override string OpenElement()
            => "input";
    }
}
