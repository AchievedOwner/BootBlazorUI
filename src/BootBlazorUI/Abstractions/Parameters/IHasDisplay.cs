using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件具有显示方式的参数。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasParameter" />
    public interface IHasDisplay : IHasParameter
    {
        /// <summary>
        /// 设置组件在任何视窗尺寸的显示方式。
        /// </summary>
        Display? Display { get; set; }
        /// <summary>
        /// 设置组件在小视窗尺寸的显示方式。
        /// </summary>
        Display? DisplaySM { get; set; }
        /// <summary>
        /// 设置组件在中视窗尺寸的显示方式。
        /// </summary>
        Display? DisplayMD { get; set; }
        /// <summary>
        /// 设置组件在大视窗尺寸的显示方式。
        /// </summary>
        Display? DisplayLG { get; set; }

        /// <summary>
        /// 设置组件在超大视窗尺寸的显示方式。
        /// </summary>
        Display? DisplayXL { get; set; }

        /// <summary>
        /// 设置组件显示的位置参数。
        /// </summary>
        DisplayPosition? Position { get; set; }
        /// <summary>
        /// 设置组件的位置固定在浏览器的顶部。
        /// </summary>
        bool? FixedTop { get; set; }
        /// <summary>
        /// 设置组件的位置固定在浏览器的底部。
        /// </summary>
        bool? FixedBottom { get; set; }
        /// <summary>
        /// 设置根据正常文档流进行定位。
        /// </summary>
        bool? StickyTop { get; set; }

        /// <summary>
        /// 设置组件相对于 <see cref="Position"/> 参数的设置左边的距离。
        /// </summary>
        string Left { get; set; }

        /// <summary>
        /// 设置组件相对于 <see cref="Position"/> 参数的设置右边的距离。
        /// </summary>
        string Right { get; set; }

        /// <summary>
        /// 设置组件相对于 <see cref="Position"/> 参数的设置顶部的距离。
        /// </summary>
        string Top { get; set; }

        /// <summary>
        /// 设置组件相对于 <see cref="Position"/> 参数的设置底部的距离。
        /// </summary>
        string Bottom { get; set; }
    }
}
