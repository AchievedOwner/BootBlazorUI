using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示使用默认按钮触发下拉菜单的容器。
    /// </summary>
    partial class BootDropDown
    {
        /// <summary>
        /// 设置下拉菜单的颜色主题。默认 <see cref="Color.Primary"/>。
        /// </summary>
        [Parameter] public Color Color { get; set; } = Color.Primary;
        /// <summary>
        /// 设置下拉菜单的尺寸。
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.Default;
        /// <summary>
        /// 设置显示下拉菜单的内容。
        /// </summary>
        [Parameter]public RenderFragment Content { get; set; }
        /// <summary>
        /// 设置下拉菜单的选项。
        /// </summary>
        [Parameter]public RenderFragment DropDownItems { get; set; }
        /// <summary>
        /// 设置下拉菜单选项展开的方向。默认 <see cref="Direction.Down"/>。
        /// </summary>
        public Direction DropDirection { get; set; } = Direction.Down;//暂未实现

        /// <summary>
        /// <see cref="BootDropDownMenu"/> 的引用。
        /// </summary>
        BootDropDownMenu RefMenu { get; set; }

        /// <summary>
        /// 获取组件的激活状态。
        /// </summary>
        bool IsActived { get; set; }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            if(DropDirection!= Direction.Down)
            {
                collection.Add($"drop{DropDirection.ToString().ToLower()}");
            }
            if (IsActived)
            {
                collection.Add("show");
            }
        }
    }
}
