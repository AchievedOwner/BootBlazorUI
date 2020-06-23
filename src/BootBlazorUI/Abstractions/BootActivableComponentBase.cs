using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示一个可进行激活/未激活切换的组件基类。
    /// </summary>
    public abstract class BootActivableComponentBase : BootComponentBase
    {
        /// <summary>
        /// 获取一个布尔值，表示组件是否处于激活状态。
        /// </summary>
        public bool IsActived { get;private set; }

        /// <summary>
        /// 设置当组件处于激活状态时的 css 样式名称。
        /// </summary>
        [Parameter] public string ActivedCssClass { get; set; } = "active";

        /// <summary>
        /// 设置当组件切换为激活状态时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<bool> OnActive { get; set; }
        /// <summary>
        /// 设置当组件切换为未激活状态时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<bool> OnInactive { get; set; }

        /// <summary>
        /// 设置当组件状态进行切换时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<bool> OnToggle { get; set; }

        /// <summary>
        /// 执行组件的激活操作。
        /// </summary>
        public async Task Active()
        {
            IsActived = true;
            await OnActive.InvokeAsync(IsActived);
            StateHasChanged();
        }

        /// <summary>
        /// 执行组件的不激活操作。
        /// </summary>
        public async Task Inactive()
        {
            IsActived = false;
            await OnInactive.InvokeAsync(IsActived);
            StateHasChanged();
        }
        /// <summary>
        /// 执行开关模式，若组件已激活，则恢复未激活状态；否则成为激活状态。
        /// </summary>
        public async Task Toggle()
        {
            if (IsActived)
            {
                await Inactive();
            }
            else
            {
                await Active();
            }
            await OnToggle.InvokeAsync(IsActived);
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if (IsActived)
            {
                collection.Add(ActivedCssClass);
            }
        }
    }
}
