
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义文本的对齐方式的参数。
    /// </summary>
    public interface IHasTextAlign : IHasParameter
    {
        /// <summary>
        /// 设置文本在组件中的水平对齐方式。
        /// </summary>
        /// <value>
        /// <see cref="HorizontalAlignment"/> 的枚举值或 <c>null</c>。
        /// </value>
        public HorizontalAlignment? TextAlign { get; set; }
    }
}
