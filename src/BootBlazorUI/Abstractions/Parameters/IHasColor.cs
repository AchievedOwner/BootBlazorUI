
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件具有主题颜色的参数。
    /// </summary>
    public interface IHasColor : IHasParameter
    {
        /// <summary>
        /// 设置组件的主题颜色的参数。null 表示不使用颜色。
        /// </summary>
        /// <value>
        /// <see cref="BootBlazorUI.Color"/> 的枚举值或 <c>null</c>。
        /// </value>
        public Color? Color { get; set; }
    }
}
