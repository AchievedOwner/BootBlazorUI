using System.ComponentModel;

using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 组件的通用配色方案。
    /// </summary>
    public enum Color
    {
        /// <summary>
        /// 主要的。
        /// </summary>
        [CssClass("primary")]
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        [CssClass("secondary")]
        Secondary = 2,
        /// <summary>
        /// 信息的。
        /// </summary>
        [CssClass("info")]
        Info = 3,
        /// <summary>
        /// 成功的。
        /// </summary>
        [CssClass("success")]
        Success = 4,
        /// <summary>
        /// 警告的。
        /// </summary>
        [CssClass("warning")]
        Warning = 5,
        /// <summary>
        /// 危险的。
        /// </summary>
        [CssClass("danger")]
        Danger = 6,
        /// <summary>
        /// 浅色的。
        /// </summary>
        [CssClass("light")]
        Light = 7,
        /// <summary>
        /// 深色的。
        /// </summary>
        [CssClass("dark")]
        Dark = 8,
    }


    /// <summary>
    /// 组件的背景颜色配色方案。
    /// </summary>
    public enum BgColor
    {
        /// <summary>
        /// 透明的。
        /// </summary>
        [CssClass("transparent")]
        Transparent = 0,
        /// <summary>
        /// 主要的。
        /// </summary>
        [CssClass("primary")]
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        [CssClass("secondary")]
        Secondary = 2,
        /// <summary>
        /// 信息的。
        /// </summary>
        [CssClass("info")]
        Info = 3,
        /// <summary>
        /// 成功的。
        /// </summary>
        [CssClass("success")]
        Success = 4,
        /// <summary>
        /// 警告的。
        /// </summary>
        [CssClass("warning")]
        Warning = 5,
        /// <summary>
        /// 危险的。
        /// </summary>
        [CssClass("danger")]
        Danger = 6,
        /// <summary>
        /// 浅色的。
        /// </summary>
        [CssClass("light")]
        Light = 7,
        /// <summary>
        /// 深色的。
        /// </summary>
        [CssClass("dark")]
        Dark = 8,
    }

    /// <summary>
    /// 组件的文本配色方案。
    /// </summary>
    public enum TextColor
    {
        /// <summary>
        /// 主要的。
        /// </summary>
        [CssClass("primary")]
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        [CssClass("secondary")]
        Secondary = 2,
        /// <summary>
        /// 信息的。
        /// </summary>
        [CssClass("info")]
        Info = 3,
        /// <summary>
        /// 成功的。
        /// </summary>
        [CssClass("success")]
        Success = 4,
        /// <summary>
        /// 警告的。
        /// </summary>
        [CssClass("warning")]
        Warning = 5,
        /// <summary>
        /// 危险的。
        /// </summary>
        [CssClass("danger")]
        Danger = 6,
        /// <summary>
        /// 浅色的。
        /// </summary>
        [CssClass("light")]
        Light = 7,
        /// <summary>
        /// 深色的。
        /// </summary>
        [CssClass("dark")]
        Dark = 8,
        /// <summary>
        /// 主体颜色。
        /// </summary>
        [CssClass("body")]
        Body = 9,
        /// <summary>
        /// 灰色。
        /// </summary>
        [CssClass("muted")]
        Muted = 10,
        /// <summary>
        /// 白色。
        /// </summary>
        [CssClass("white")]
        White = 11,
        /// <summary>
        /// 淡黑色。
        /// </summary>
        [CssClass("black-50")]
        Black50 = 12,
        /// <summary>
        /// 淡白色。
        /// </summary>
        [CssClass("white-50")]
        White50 = 13
    }
}
