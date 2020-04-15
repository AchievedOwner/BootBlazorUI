using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现 textarea 元素的组件。
    /// </summary>
    public class BootInputTextArea : BootInputBase<string>
    {
        /// <summary>
        /// 设置组件的初始显示的行数，超过该行数的将显示滚动条。默认是 3 行。
        /// </summary>
        [Parameter]
        public int Rows { get; set; } = 3;

        /// <summary>
        /// 设置一个布尔值，表示只读状态是否采用文本形式呈现。
        /// </summary>
        [Parameter]
        public bool ReadOnlyAsText { get; set; }

        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence++, "rows", Rows);
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
            }
        }

        protected override string OpenElement()
            => "textarea";
    }
}
