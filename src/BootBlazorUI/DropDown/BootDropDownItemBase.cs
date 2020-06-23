using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    public abstract class BootDropDownItemBase : BootComponentBase
    {
        [CascadingParameter]internal BootDropDownMenu Parent { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示组件是否被禁用。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }


        protected override void OnInitialized()
        {
            if(!(Parent is BootDropDownMenu))
            {
                throw new InvalidOperationException($"当前组件必须放在 {nameof(BootDropDownMenu)} 组件中");
            }
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if (Disabled)
            {
                collection.Add("disabled");
            }
        }
    }
}
