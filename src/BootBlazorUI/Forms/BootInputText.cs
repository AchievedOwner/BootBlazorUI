using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现 type="text" 的 input 元素的组件。
    /// </summary>
    /// <typeparam name="TValue">元素值的类型。</typeparam>
    public class BootInputText<TValue> : BootInputBase<TValue>
    {
        /// <summary>
        /// 设置组件的尺寸，默认是 <see cref="Size.Default"/>。
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置一个布尔值，表示只读状态是否采用文本形式呈现。
        /// </summary>
        [Parameter]
        public bool ReadOnlyAsText { get; set; }

        /// <summary>
        /// 定义元素的名称是 input。
        /// </summary>
        /// <returns>input 字符串。</returns>
        protected override string OpenElement()
        => "input";

        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence++, "type", "text");
        }



        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if (ReadOnly && ReadOnlyAsText)
            {
                collection.Add("form-control-plaintext");
            }
            else
            {
                collection.Add("form-control");
                if (Size != Size.Default)
                {
                    collection.Add(ComponentUtil.GetSizeCssClass(Size, "form-control-"));
                }
            }
        }
    }
}
