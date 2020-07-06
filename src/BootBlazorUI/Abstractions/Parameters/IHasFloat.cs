using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件包含层的浮动参数。
    /// </summary>
    public interface IHasFloat
    {
        /// <summary>
        /// 设置一个布尔值，表示清除组件的浮动。
        /// </summary>
        public bool? ClearFix { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示组件使用左浮动。
        /// </summary>
        public bool? FloatLeft { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示组件使用右浮动。
        /// </summary>
        public bool? FloatRight { get; set; }
    }
}
