using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现具有 style="position:absolute" 样式的 Loading 遮罩层。
    /// </summary>
    public partial class BootLoading
    {
        /// <summary>
        /// 初始化 <see cref="BootLoading"/> 类的新实例。
        /// </summary>
        public BootLoading()
        {
            ChildContent = builder =>
            {
                builder.OpenComponent<BootSpinner>(0);
                builder.AddAttribute(1, "AdditionalCssClass", "mr-1");
                builder.AddAttribute(2, "Size", Size.SM);
                builder.CloseComponent();
                builder.AddMarkupContent(3, "正在拼命加载中...");
            };
        }
        /// <summary>
        /// 设置要呈现在遮罩层的内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置遮罩层的背景颜色。默认是 <see cref="Color.Light"/> 。
        /// </summary>
        [Parameter] public Color Color { get; set; } = Color.Light;
        /// <summary>
        /// 设置遮罩层的透明度。默认 0.5。值在0-1之间。
        /// </summary>
        [Parameter] public double Opacity { get; set; } = 0.5;
        /// <summary>
        /// 设置遮罩层显示内容的纵向对齐方式。默认是 <see cref="Flex.Center"/> 居中显示。
        /// </summary>
        [Parameter] public Flex HorizontalAlign { get; set; } = Flex.Center;
        /// <summary>
        /// 设置一个布尔值，表示是否显示该组件。
        /// </summary>
        [Parameter] public bool IsShown { get; set; }

        /// <summary>
        /// 设置一个超时时间，单位是秒。超过该时间后组件将自动隐藏，null 表示不会自动隐藏。
        /// </summary>
        [Parameter] public int? Timeout { get; set; }
        /// <summary>
        /// 设置当组件显示后触发的事件。
        /// </summary>
        [Parameter] public EventCallback<bool> OnShown { get; set; }
        /// <summary>
        /// 设置当组件隐藏后触发的事件。
        /// </summary>
        [Parameter] public EventCallback<bool> OnHidden { get; set; }


        /// <summary>
        /// 显示遮罩层。
        /// </summary>
        public async Task Show()
        {
            IsShown = true;
            await OnShown.InvokeAsync(true);

            StartCountdownForTimeout();

            StateHasChanged();
        }

        private void StartCountdownForTimeout()
        {
            if (Timeout.HasValue)
            {
                timer = new System.Threading.Timer(async (state) =>
                {
                    await InvokeAsync(async () =>
                    {
                        if (IsShown)
                        {
                            await Hide();
                            timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                        }
                    });
                }, null, dueTime: Timeout.Value * 1000, period: 1000);
            }
        }

        /// <summary>
        /// 隐藏遮罩层。
        /// </summary>
        public async Task Hide()
        {
            IsShown = false;
            await OnHidden.InvokeAsync(true);
            StateHasChanged();
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("position-absolute");
            collection.Add(ComponentUtil.GetColorCssClass(Color, "bg-"));
            collection.Add("w-100");
            collection.Add("overflow-hidden");
            collection.Add(IsShown ? "d-flex" : "d-none");
            collection.Add("flex-column flex-fill");
        }

        protected override void CreateComponentStyle(ICollection<string> collection)
        {
            collection.Add("height:100%");
            collection.Add("line-height:100%");
            collection.Add($"opacity:{Math.Round(Opacity, 1)}");
            collection.Add("top:0");
            collection.Add("left:0");
        }

        System.Threading.Timer timer;
    }
}
