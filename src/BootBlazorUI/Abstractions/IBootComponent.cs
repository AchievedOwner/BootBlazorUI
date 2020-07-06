using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 提供 Boot 组件的功能。
    /// </summary>
    public interface IBootComponent : IComponent
    {
        /// <summary>
        /// 构造组件的 class 样式名称并用空格连接的字符串。
        /// </summary>
        /// <returns>用空格分割的样式字符串。</returns>
        string BuildCssClassString();
        /// <summary>
        /// 构造组件的 style 的值并用“;”连接。
        /// </summary>
        /// <returns>用分号隔开的 style 样式。</returns>
        string BuildStylesString();
    }
}
