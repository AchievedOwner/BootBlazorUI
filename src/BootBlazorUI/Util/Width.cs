using System.ComponentModel;

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
        [Description("auto")]
        Auto = 0,
        /// <summary>
        /// 宽度为 25%。
        /// </summary>
        [Description("25")]
        W25 = 25,
        /// <summary>
        /// 宽度为 50%。
        /// </summary>
        [Description("50")]
        W50 = 50,
        /// <summary>
        /// 宽度为 75%。
        /// </summary>
        [Description("75")]
        W75 = 75,
        /// <summary>
        /// 宽度为 100%。
        /// </summary>
        [Description("100")]
        W100 = 100
    }
}
