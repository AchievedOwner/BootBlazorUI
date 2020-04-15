using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现可进行折叠的 div 元素。
    /// </summary>
    public class BootCollapse:BootComponentBase
    {
        /// <summary>
        /// 设置面板的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 获取一个布尔值，表示面板是否处于展开状态。
        /// </summary>
        public bool IsExpand { get; private set; }

        /// <summary>
        /// 设置当面板展开时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnExpanded { get; set; }
        /// <summary>
        /// 设置当面板收缩时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnCollapsed { get; set; }

        /// <summary>
        /// 对伸缩面板进行展开操作。
        /// </summary>
        public async Task Expand()
        {
            IsExpand = true;
            await OnExpanded.InvokeAsync(IsExpand);
            StateHasChanged();
        }

        /// <summary>
        /// 对面板进行收缩操作。
        /// </summary>
        public async Task Collapse()
        {    
            IsExpand = false;
            await OnCollapsed.InvokeAsync(IsExpand);
            StateHasChanged();
        }

        /// <summary>
        /// 如果面板处于伸缩状态，则会进行展开，否则会进行收缩。
        /// </summary>
        public async Task Toggle()
        {
            if (IsExpand)
            {
                await Collapse();
            }
            else
            {
                await Expand();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("collapse");
            collection.Add("fade");
            if (IsExpand)
            {
                collection.Add("show");
            }
        }
    }
}
