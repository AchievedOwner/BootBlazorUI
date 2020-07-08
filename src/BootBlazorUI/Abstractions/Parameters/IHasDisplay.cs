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
    }
}
