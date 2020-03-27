﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示标签控件。
    /// </summary>
    partial class BootTabControl
    {
       

        /// <summary>
        /// 设置包含 <see cref="BootTabPage"/> 的标签页。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 表示启用页面。
        /// </summary>
        internal BootTabPage ActivedPage { get; set; }

        /// <summary>
        /// 获取所有的页面。
        /// </summary>
        List<BootTabPage> Pages { get; set; } = new List<BootTabPage>();

        /// <summary>
        /// 设置一个布尔值，表示标签页是否使用药丸样式。
        /// </summary>
        [Parameter]
        public bool Pills { get; set; }



        /// <summary>
        /// 设置标签页的固定高度。
        /// </summary>
        [Parameter]
        public string MinHeight { get; set; } = "100px;";

        /// <summary>
        /// 添加一个标签页面。
        /// </summary>
        /// <param name="page">要添加的标签页面。</param>
        internal void AddPage(BootTabPage page)
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
        string GetActiveClass(BootTabPage page)
        {
            return ActivedPage == page ? "active" : string.Empty;
        }

        /// <summary>
        /// 激活指定的标签页面。
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        async Task ActivePage(BootTabPage page)
        {
            await page.OnActived.InvokeAsync(page);
            ActivedPage = page;
        }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("nav");

            if (Pills)
            {
                classList.Add("nav-pills");
            }
            else
            {
                classList.Add("nav-tabs");
            }
        }

        protected override void BuildStyles(List<string> styleList)
        {
            if (!string.IsNullOrWhiteSpace(MinHeight))
            {
                styleList.Add($"min-height:{MinHeight}");
            }
        }
    }
}
