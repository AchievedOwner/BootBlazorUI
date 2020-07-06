using System.ComponentModel;

namespace BootBlazorUI
{
    /// <summary>
    /// 组件的配色方案。
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
        Dark = 8
    }
}
