using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 设置组件的可见性参数。
    /// </summary>
    public interface IHasVisibility
    {
        /// <summary>
        /// 设置组件的可见性，但依然占据位置。
        /// </summary>
        bool? Visibility { get; set; }
    }
}
