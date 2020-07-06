
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件具有尺寸的参数。
    /// </summary>
    public interface IHasSize : IHasParameter
    {
        /// <summary>
        /// 设置组件尺寸的参数。null 表示不使用尺寸。
        /// </summary>
        /// <value>
        /// <see cref="BootBlazorUI.Size"/> 的枚举值或 <c>null</c>。
        /// </value>
        public Size? Size { get; set; }
    }
}
