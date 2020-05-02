using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 ul 元素的标签页面组件。
    /// </summary>
    partial class BootTabControl
    {
        /// <summary>
        /// 初始化 <see cref="BootTabControl"/> 类的新实例
        /// </summary>
        public BootTabControl()
        {

        }  

        /// <summary>
        /// 设置包含 <see cref="BootTabControlPage"/> 的标签页。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 表示启用页面。
        /// </summary>
        internal BootTabControlPage ActivedPage { get; set; }

        /// <summary>
        /// 获取所有的页面。
        /// </summary>
        List<BootTabControlPage> Pages { get; set; } = new List<BootTabControlPage>();

        /// <summary>
        /// 设置一个布尔值，表示标签页是否使用药丸样式。
        /// </summary>
        [Parameter]
        public bool Pills { get; set; }



        /// <summary>
        /// 设置最小高度，单位像素。默认 100。
        /// </summary>
        [Parameter] public int? MinHeight { get; set; } = 100;


        /// <summary>
        /// 设置最大高度，单位像素。超过该高度则显示滚动条。
        /// </summary>
        [Parameter] public int? MaxHeight { get; set; }


        /// <summary>
        /// 设置固定高度，单位像素。超过该高度则显示滚动条。
        /// </summary>
        [Parameter] public int? Height { get; set; }

        /// <summary>
        /// 添加一个标签页面。
        /// </summary>
        /// <param name="page">要添加的标签页面。</param>
        internal void AddPage(BootTabControlPage page)
        {
            Pages.Add(page);
            if (Pages.Count == 1)
            {
                ActivedPage = page;
            }
            StateHasChanged();
        }

        /// <summary>
        /// 获取启用样式。
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        string GetActiveClass(BootTabControlPage page)
        {
            return ActivedPage == page ? "active" : string.Empty;
        }

        /// <summary>
        /// 激活指定的标签页面。
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        async Task ActivePage(BootTabControlPage page)
        {
            await page.OnActived.InvokeAsync(page);
            ActivedPage = page;
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("nav");

            if (Pills)
            {
                collection.Add("nav-pills");
            }
            else
            {
                collection.Add("nav-tabs");
            }
        }

        protected override void CreateComponentStyle(ICollection<string> collection)
        {
            if (MinHeight.HasValue)
            {
                collection.Add($"min-height:{MinHeight.Value}px");
            }

            if (MaxHeight.HasValue)
            {
                collection.Add($"max-height:{MaxHeight.Value}px;overflow-y:auto");
            }

            if (Height.HasValue)
            {
                collection.Add($"height:{Height.Value}px;overflow-y:auto");
            }
        }
    }
}
