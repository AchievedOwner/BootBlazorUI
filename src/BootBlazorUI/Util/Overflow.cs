using System.ComponentModel;

using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 规定当内容溢出元素框时发生的事情。
    /// </summary>
    public enum Overflow
    {
        /// <summary>
        /// 自动根据溢出内容呈现滚动条。
        /// </summary>
        [CssClass("auto")]
        Auto = 1,
        /// <summary>
        /// 内容会被修剪，并且其余内容是不可见的。
        /// </summary>
        [CssClass("hidden")]
        Hidden = 2
    }

    /// <summary>
    /// 规定当内容溢出元素框时发生的事情。
    /// </summary>
    public enum OverflowStyle
    {
        /// <summary>
        /// 内容不会被修剪，会呈现在元素框之外。
        /// </summary>
        [CssClass("visible")]
        Visible = 0,
        /// <summary>
        /// 如果内容被修剪，则浏览器会显示滚动条以便查看其余的内容。
        /// </summary>
        [CssClass("auto")]
        Auto = 1,
        /// <summary>
        /// 内容会被修剪，并且其余内容是不可见的。
        /// </summary>
        [CssClass("hidden")]
        Hidden = 2,
        /// <summary>
        /// 内容会被修剪，但是浏览器会显示滚动条以便查看其余的内容。
        /// </summary>
        [CssClass("scroll")]
        Scroll = 3
    }
}
