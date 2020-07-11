using System.ComponentModel;

using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 组件的高度比例。
    /// </summary>
    public enum Height
    {
        /// <summary>
        /// 高度比例是自动的。
        /// </summary>
        [CssClass("auto")]
        Auto=0,
        /// <summary>
        /// 高度比例是 25%。
        /// </summary>
        [CssClass("25")]
        H25 = 25,
        /// <summary>
        /// 高度比例是 50%。
        /// </summary>
        [CssClass("50")]
        H50 = 50,
        /// <summary>
        /// 高度比例是 75%。
        /// </summary>
        [CssClass("75")]
        H75 = 75,
        /// <summary>
        /// 高度比例是 100%。
        /// </summary>
        [CssClass("100")]
        H100 = 100
    }
}
