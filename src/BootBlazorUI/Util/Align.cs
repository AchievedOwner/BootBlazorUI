﻿using System.ComponentModel;

namespace BootBlazorUI
{
    /// <summary>
    /// 横向对齐方式。
    /// </summary>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// 左对齐。
        /// </summary>
        [Description("left")]
        Left,
        /// <summary>
        /// 居中对齐。
        /// </summary>
        [Description("center")]
        Center,
        /// <summary>
        /// 右对齐。
        /// </summary>
        [Description("right")]
        Right
    }

    /// <summary>
    /// 垂直对齐方式。
    /// </summary>
    public enum VerticalAlignment
    {
        /// <summary>
        /// 顶部对齐。
        /// </summary>
        Top,
        /// <summary>
        /// 居中对齐。
        /// </summary>
        Middle,
        /// <summary>
        /// 底部对齐。
        /// </summary>
        Bottom
    }

    /// <summary>
    /// flex 布局的对齐方式。
    /// </summary>
    public enum Flex
    {
        /// <summary>
        /// 从顶端开始。
        /// </summary>
        Start,
        /// <summary>
        /// 从末端开始。
        /// </summary>
        End,
        /// <summary>
        /// 居中显示。
        /// </summary>
        Center,
        /// <summary>
        /// 两端显示。
        /// </summary>
        Between,
        /// <summary>
        /// 环绕显示。
        /// </summary>
        Around,
    }
    /// <summary>
    /// 表示方向的枚举。
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// 向上。
        /// </summary>
        Up,
        /// <summary>
        /// 向下。
        /// </summary>
        Down,
        /// <summary>
        /// 向左。
        /// </summary>
        Left,
        /// <summary>
        /// 向右。
        /// </summary>
        Right
    }

    /// <summary>
    /// 呈现元素的位置。
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// 顶部。
        /// </summary>
        [Description("top")]
        Top = 1,
        /// <summary>
        /// 底部。
        /// </summary>
        [Description("bottom")]
        Bottom = 2,
        /// <summary>
        /// 左侧。
        /// </summary>
        [Description("left")]
        Left = 3,
        /// <summary>
        /// 右侧。
        /// </summary>
        [Description("right")]
        Right = 4
    }
}
