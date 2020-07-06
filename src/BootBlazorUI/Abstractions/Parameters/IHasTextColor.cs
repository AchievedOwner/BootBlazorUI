
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的文本颜色。
    /// </summary>
    public interface IHasTextColor : IHasParameter
    {
        /// <summary>
        /// 设置组件的文本颜色。
        /// </summary>
        /// <value>
        /// <see cref="Color"/> 的枚举值或 <c>null</c>。
        /// </value>
        public Color? TextColor { get; set; }
    }
}
