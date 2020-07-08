using System.ComponentModel;

namespace BootBlazorUI
{
    /// <summary>
    /// 浏览器尺寸适配的视角选项。参考 https://v4.bootcss.com/docs/layout/overview/.
    /// </summary>
    public enum ViewPoint
    {
        /// <summary>
        /// 极小尺寸。
        /// </summary>
        [Description("xs")]
        XS = 0,
        /// <summary>
        /// 最小尺寸。
        /// </summary>
        [Description("sm")]
        SM = 1,
        /// <summary>
        ///  中等尺寸。
        /// </summary>
        [Description("md")]
        MD = 2,
        /// <summary>
        ///  较大尺寸。
        /// </summary>
        [Description("lg")]
        LG = 3,
        /// <summary>
        ///  最大尺寸。
        /// </summary>
        [Description("xl")]
        XL = 4
    }
}
