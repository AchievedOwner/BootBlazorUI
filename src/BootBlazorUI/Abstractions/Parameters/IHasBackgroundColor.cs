
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的背景颜色。
    /// </summary>
    public interface IHasBackgroundColor : IHasParameter
    {
        /// <summary>
        /// 设置组件的背景颜色。
        /// </summary>
        /// <value>
        /// <see cref="Color"/> 的枚举值或 <c>null</c>。
        /// </value>
        public Color? BackgroundColor { get; set; }
    }
}
