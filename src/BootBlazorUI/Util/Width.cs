using System.ComponentModel;

using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 定义宽度的 css 名称。
    /// </summary>
    public enum Width
    {
        /// <summary>
        /// 宽度为自动。
        /// </summary>
        [CssClass("auto")]
        Auto = 0,
        /// <summary>
        /// 宽度为 25%。
        /// </summary>
        [CssClass("25")]
        W25 = 25,
        /// <summary>
        /// 宽度为 50%。
        /// </summary>
        [CssClass("50")]
        W50 = 50,
        /// <summary>
        /// 宽度为 75%。
        /// </summary>
        [CssClass("75")]
        W75 = 75,
        /// <summary>
        /// 宽度为 100%。
        /// </summary>
        [CssClass("100")]
        W100 = 100
    }
}
