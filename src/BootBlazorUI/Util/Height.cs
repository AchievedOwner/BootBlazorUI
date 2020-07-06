using System.ComponentModel;

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
        [Description("auto")]
        Auto=0,
        /// <summary>
        /// 高度比例是 25%。
        /// </summary>
        [Description("25")]
        H25 = 25,
        /// <summary>
        /// 高度比例是 50%。
        /// </summary>
        [Description("50")]
        H50 = 50,
        /// <summary>
        /// 高度比例是 75%。
        /// </summary>
        [Description("75")]
        H75 = 75,
        /// <summary>
        /// 高度比例是 100%。
        /// </summary>
        [Description("100")]
        H100 = 100
    }
}
