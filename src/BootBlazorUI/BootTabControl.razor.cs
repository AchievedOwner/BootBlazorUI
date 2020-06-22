using System;
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
        /// 获取所有的页面。
        /// </summary>
        internal List<BootTabControlPage> Pages { get; set; } = new List<BootTabControlPage>();

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
        /// 设置一个布尔值，表示是否使用代码来切换选项卡。若设置为 <c>true</c>，则需要调用 <see cref="SwitchTo(int)"/> 切换指定索引的选项卡。
        /// </summary>
        [Parameter] public bool UseCode { get; set; }

        /// <summary>
        /// 设置当切换选项卡时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> OnSwtich { get; set; }

        /// <summary>
        /// 激活的标签页索引。
        /// </summary>
        internal int ActivedTabPageIndex { get; set; } = -1;



        /// <summary>
        /// 添加一个标签页面。
        /// </summary>
        /// <param name="page">要添加的标签页面。</param>
        public void AddPage(BootTabControlPage page)
        {
            Pages.Add(page);
            if (Pages.Count == 1)
            {
                ActivedTabPageIndex = 0;
            }
            StateHasChanged();            
        }

        /// <summary>
        /// 获取启用样式。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string GetActiveClass(int index) => ActivedTabPageIndex == index ? "active" : null;

        /// <summary>
        /// 切换选项卡。
        /// </summary>
        /// <param name="index">要切换的索引。</param>
        /// <returns></returns>
        async Task Switch(int index)
        {
            if (!UseCode)
            {
                await SwitchTo(index);
            }
            await OnSwtich.InvokeAsync(index);
        }

        /// <summary>
        /// 切换指定索引的选项卡。
        /// </summary>
        /// <param name="index">选项卡索引。</param>
        public async Task SwitchTo(int index)
        {
            if (index < 0)
            {
                ActivedTabPageIndex = -1;
                return;
            }

            var activedPage = Pages[index];
            ActivedTabPageIndex = index;
            await activedPage.OnActived.InvokeAsync(activedPage);
        }

        /// <summary>
        /// 创建组件的 css 类集合。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
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

        /// <summary>
        /// 创建组件的样式。
        /// </summary>
        /// <param name="collection">样式集合。</param>
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
