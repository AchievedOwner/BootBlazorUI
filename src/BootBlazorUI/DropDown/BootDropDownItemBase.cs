using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    using Abstractions;
    /// <summary>
    /// 表示下拉菜单的基类。这是一个抽象类。
    /// </summary>
    public abstract class BootDropDownItemBase : BootComponentBase
    {
        /// <summary>
        /// 下来菜单组件。
        /// </summary>
        [CascadingParameter]internal BootDropDownMenu Parent { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示组件是否被禁用。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// 初始化组件。
        /// </summary>
        protected override void OnInitialized()
        {
            if(!(Parent is BootDropDownMenu))
            {
                throw new InvalidOperationException($"当前组件必须放在 {nameof(BootDropDownMenu)} 组件中");
            }
        }

        /// <summary>
        /// 创建组件所需要的 css。
        /// </summary>
        /// <param name="collection">css 集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if (Disabled)
            {
                collection.Add("disabled");
            }
        }
    }
}
