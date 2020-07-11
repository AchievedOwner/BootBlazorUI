using System.ComponentModel;

using YoiBlazor;

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
        [CssClass("left")]
        Left,
        /// <summary>
        /// 居中对齐。
        /// </summary>
        [CssClass("center")]
        Center,
        /// <summary>
        /// 右对齐。
        /// </summary>
        [CssClass("right")]
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
        [CssClass("top")]
        Top = 1,
        /// <summary>
        /// 底部。
        /// </summary>
        [CssClass("bottom")]
        Bottom = 2,
        /// <summary>
        /// 左侧。
        /// </summary>
        [CssClass("left")]
        Left = 3,
        /// <summary>
        /// 右侧。
        /// </summary>
        [CssClass("right")]
        Right = 4
    }

    /// <summary>
    /// 元素显示的定位。
    /// </summary>
    public enum DisplayPosition
    {
        /// <summary>
        /// 默认值。没有定位，元素出现在正常的流中。
        /// </summary>
        [CssClass("static")]
        Static = 0,
        /// <summary>
        /// 生成相对定位的元素，相对于其正常位置进行定位。
        /// </summary>
        [CssClass("relative")]
        Relative = 1,
        /// <summary>
        /// 生成绝对定位的元素，相对于 static 定位以外的第一个父元素进行定位。
        /// </summary>
        [CssClass("absolute")]
        Absolute = 2,
        /// <summary>
        /// 生成绝对定位的元素，相对于浏览器窗口进行定位。元素的位置通过 "left", "top", "right" 以及 "bottom" 属性进行规定。
        /// </summary>
        [CssClass("fixed")]
        Fixed = 3,
        /// <summary>
        /// 生成吸附性定位的元素，相对于浏览器窗口进行定位。元素的位置通过 "left", "top", "right" 以及 "bottom" 属性进行规定。
        /// </summary>
        [CssClass("sticky")]
        Sticky=4,
    }
}
