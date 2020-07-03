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
        /// <summary>
        /// 构造输入组件的渲染树。
        /// </summary>
        /// <param name="builder">渲染构造器。</param>
        /// <param name="sequence">系列。</param>
        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence++, "rows", Rows);
        }
        /// <summary>
        /// 构建组件内置的 class 样式。
        /// </summary>
        /// <param name="collection"></param>
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
        /// <summary>
        /// 定义组件的元素名称。
        /// </summary>
        /// <returns>
        /// 组件元素的名称字符串。
        /// </returns>
        protected override string OpenElement()
            => "textarea";
    }
}
