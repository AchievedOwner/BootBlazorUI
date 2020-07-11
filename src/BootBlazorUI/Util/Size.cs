using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 控件的尺寸。某些尺寸只有在特定的样式才生效，具体可查看定义。
    /// </summary>
    public enum Size
    {
        /// <summary>
        /// 超小尺寸。
        /// </summary>
        [CssClass("xs")]
        XS = 0,
        /// <summary>
        /// 小尺寸。
        /// </summary>
        [CssClass("sm")]
        SM = 1,
        /// <summary>
        /// 大尺寸。
        /// </summary>
        [CssClass("lg")]
        LG = 2,
        
        /// <summary>
        /// 超大尺寸。
        /// </summary>
        [CssClass("xl")]
        XL = 3,
    }
}
