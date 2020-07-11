using System.ComponentModel;

using YoiBlazor;

namespace BootBlazorUI
{
    /// <summary>
    /// 组件的显示方式。
    /// </summary>
    public enum Display
    {
        /// <summary>
        /// 元素不会被显示。
        /// </summary>
        [CssClass("none")]
        None = 0,
        /// <summary>
        /// 此元素会被显示为内联元素，元素前后没有换行符。
        /// </summary>
        [CssClass("inline")]
        Inline = 1,
        /// <summary>
        /// 行内块元素。
        /// </summary>
        InlineBlock = 2,
        /// <summary>
        /// 此元素将显示为块级元素，此元素前后会带有换行符。
        /// </summary>
        [CssClass("block")]
        Block = 3,
        /// <summary>
        /// 此元素会作为块级表格来显示（类似 &lt;table>），表格前后带有换行符。
        /// </summary>
        [CssClass("table")]
        Table = 4,
        /// <summary>
        /// 此元素会作为一个表格单元格显示（类似 &lt;td> 和 &lt;th>）
        /// </summary>
        [CssClass("table-cell")]
        TableCell = 5,
        /// <summary>
        /// 此元素会作为一个表格行显示（类似 &lt;tr>）。
        /// </summary>
        [CssClass("table-row")]
        TableRow = 6,
        /// <summary>
        /// 此元素会作为弹性伸缩盒显示。
        /// </summary>
        [CssClass("flex")]
        Flex = 7,
        /// <summary>
        /// 此元素会作为内联块级弹性伸缩盒显示。
        /// </summary>
        [CssClass("inline-flex")]
        InlineFlex = 8
    }
}
