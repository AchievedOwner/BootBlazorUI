﻿namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的阴影效果的参数。
    /// </summary>
    public interface IHasShadow
    {
        /// <summary>
        /// 设置一个布尔值，表示是否在所有的视窗使用阴影。
        /// </summary>
        public bool? Shadow { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在小尺寸的视窗使用阴影。
        /// </summary>
        public bool? ShadowSM { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在中等尺寸的视窗使用阴影。
        /// </summary>
        public bool? ShadowMD{ get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在大尺寸的视窗使用阴影。
        /// </summary>
        public bool? ShadowLG { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在超大尺寸的视窗使用阴影。
        /// </summary>
        public bool? ShadowXL{ get; set; }
    }
}