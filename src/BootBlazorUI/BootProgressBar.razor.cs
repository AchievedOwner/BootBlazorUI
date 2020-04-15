using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示进度条。
    /// </summary>
    public partial class BootProgressBar
    {
        /// <summary>
        /// 初始化 <see cref="BootProgressBar"/> 类的新实例。
        /// </summary>
        public BootProgressBar()
        {

        }

        /// <summary>
        /// 设置进度条的主题颜色。默认是 <see cref="Color.Primary"/> 。
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// 设置进度条的最大值，默认是 100。
        /// </summary>
        [Parameter]
        public decimal Max { get; set; } = 100;

        /// <summary>
        /// 设置进度条的最小值，默认是 0，不能小于 0。
        /// </summary>
        [Parameter]
        public decimal Min { get; set; }
        /// <summary>
        /// 设置进度条当前的值，必须在 <see cref="Min"/> 和 <see cref="Max"/> 之间。
        /// </summary>
        [Parameter]
        public decimal Value { get; set; }

        /// <summary>
        /// 设置进度条的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置进度条自定义模板。
        /// </summary>
        [Parameter]
        public RenderFragment<BootProgressBar> Template { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示进度条是否呈现花纹状。
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// 设置进度条的高度。单位是px。
        /// </summary>
        [Parameter]
        public int? Height { get; set; }

        /// <summary>
        /// 获取根据设置的 <see cref="Min"/> 和 <see cref="Max"/> 以及当前的 <see cref="Value"/> 计算进度条的百分比。
        /// </summary>
        public decimal Percentage => Math.Round((Value / (Max - Min)) * 100, 0);

        [Inject]
        private IJSRuntime JS { get; set; }

        protected override void OnInitialized()
        {
            if (Min < 0 || Max < 0)
            {
                throw new ArgumentException($"{Min}和{Max}的值必须大于0");
            }
            if (Min >= Max)
            {
                throw new ArgumentException($"{Min}的值必须小于{Max}的值");
            }
            if (Value < Min || Value > Max)
            {
                throw new ArgumentException($"{Value}的值不能小于{Min}，且不能大于{Max}");
            }
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add(ComponentUtil.GetColorCssClass(Color,"bg-"));
            collection.Add("progress-bar");
            if (Striped)
            {
                collection.Add("progress-bar-striped");
            }
        }

        protected override void CreateComponentStyle(ICollection<string> collection)
        {
            if (Height.HasValue)
            {
                collection.Add($"height:{Height}px");
            }
        }

        /// <summary>
        /// 尝试更新进度条的值为指定的值。
        /// </summary>
        /// <param name="value">要更新的值。</param>
        /// <returns>一个尝试更新值的任务，任务包含布尔值，表示更新成功返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public async Task<bool> TryUpdateValue(decimal value)
        {
            if (value < Min || value > Max)
            {
                return false;
            }
            Value = value;
            await JS.InvokeVoidAsync("bootBlazor.progressBar.onValueChanged", Id, value, Percentage);
            return true;
        }
    }
}
