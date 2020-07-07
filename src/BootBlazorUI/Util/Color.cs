using System.ComponentModel;

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
        [Description("primary")]
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        [Description("secondary")]
        Secondary = 2,
        /// <summary>
        /// 信息的。
        /// </summary>
        [Description("info")]
        Info = 3,
        /// <summary>
        /// 成功的。
        /// </summary>
        [Description("success")]
        Success = 4,
        /// <summary>
        /// 警告的。
        /// </summary>
        [Description("warning")]
        Warning = 5,
        /// <summary>
        /// 危险的。
        /// </summary>
        [Description("danger")]
        Danger = 6,
        /// <summary>
        /// 浅色的。
        /// </summary>
        [Description("light")]
        Light = 7,
        /// <summary>
        /// 深色的。
        /// </summary>
        [Description("dark")]
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
        [Description("transparent")]
        Transparent = 0,
        /// <summary>
        /// 主要的。
        /// </summary>
        [Description("primary")]
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        [Description("secondary")]
        Secondary = 2,
        /// <summary>
        /// 信息的。
        /// </summary>
        [Description("info")]
        Info = 3,
        /// <summary>
        /// 成功的。
        /// </summary>
        [Description("success")]
        Success = 4,
        /// <summary>
        /// 警告的。
        /// </summary>
        [Description("warning")]
        Warning = 5,
        /// <summary>
        /// 危险的。
        /// </summary>
        [Description("danger")]
        Danger = 6,
        /// <summary>
        /// 浅色的。
        /// </summary>
        [Description("light")]
        Light = 7,
        /// <summary>
        /// 深色的。
        /// </summary>
        [Description("dark")]
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
        [Description("primary")]
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        [Description("secondary")]
        Secondary = 2,
        /// <summary>
        /// 信息的。
        /// </summary>
        [Description("info")]
        Info = 3,
        /// <summary>
        /// 成功的。
        /// </summary>
        [Description("success")]
        Success = 4,
        /// <summary>
        /// 警告的。
        /// </summary>
        [Description("warning")]
        Warning = 5,
        /// <summary>
        /// 危险的。
        /// </summary>
        [Description("danger")]
        Danger = 6,
        /// <summary>
        /// 浅色的。
        /// </summary>
        [Description("light")]
        Light = 7,
        /// <summary>
        /// 深色的。
        /// </summary>
        [Description("dark")]
        Dark = 8,
        /// <summary>
        /// 主体颜色。
        /// </summary>
        [Description("body")]
        Body = 9,
        /// <summary>
        /// 灰色。
        /// </summary>
        [Description("muted")]
        Muted = 10,
        /// <summary>
        /// 白色。
        /// </summary>
        [Description("white")]
        White = 11,
        /// <summary>
        /// 淡黑色。
        /// </summary>
        [Description("black-50")]
        Black50 = 12,
        /// <summary>
        /// 淡白色。
        /// </summary>
        [Description("white-50")]
        White50 = 13
    }
}
