using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 nav 元素，包含带有分页的组件。
    /// </summary>
    partial class BootPagination
    {
        /// <summary>
        /// 初始化 <see cref="BootPagination"/> 类的新实例。
        /// </summary>
        public BootPagination()
        {

        }

        #region 参数
        /// <summary>
        /// 设置当前页码，必须大于 0。默认是 1。
        /// </summary>
        [Parameter] public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// 设置每一页呈现的数据量。默认使用 <see cref="PageSizeStakeholders"/> 的第1个元素。
        /// <para>
        /// 在使用双向绑定支持时，建议只获取而不修改，以免造成与 <see cref="PageSizeStakeholders"/> 值不匹配的问题。
        /// </para>
        /// </summary>

        [Parameter] public int PageSize { get; set; }

        /// <summary>
        /// 设置每页呈现数据量的候选选项。默认是 10 20 30。
        /// </summary>
        [Parameter] public int[] PageSizeStakeholders { get; set; } = new[] { 10, 20, 30 };

        /// <summary>
        /// 设置数据的总记录数。
        /// </summary>
        [Parameter] public int TotalCount { get; set; }

        /// <summary>
        /// 设置分页的尺寸。
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置一个布尔值，表示是否显示总记录数统计，默认是 <c>true</c>。
        /// </summary>
        [Parameter] public bool ShowTotalCount { get; set; } = true;

        /// <summary>
        /// 设置一个布尔值，表示是否显示“跳转到”的组件。默认是 <c>true</c>。
        /// </summary> 
        [Parameter] public bool ShowNavigateTo { get; set; } = true;

        /// <summary>
        /// 设置显示页码的个数，范围是5-21的奇数。默认是 7 个。
        /// </summary>
        [Parameter] public int PageNumberCount { get; set; } = 7;
        #endregion
        #region 事件

        /// <summary>
        /// 设置当页码发生变更后触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> CurrentPageChanged { get; set; }
        /// <summary>
        /// 设置当每页呈现的数据量发生变更后触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> PageSizeChanged { get; set; }
        /// <summary>
        /// 设置当总记录数发生变更后触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> TotalCountChanged { get; set; }
        #endregion


        /// <summary>
        /// 获取总页数。
        /// </summary>
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;

        protected override void OnInitialized()
        {
            if (CurrentPage <= 0)
            {
                throw new ArgumentException("不能小于1", nameof(CurrentPage));
            }

            if (PageSizeStakeholders == null || PageSizeStakeholders.Length == 0)
            {
                throw new ArgumentException("至少要有1个元素", nameof(PageSizeStakeholders));
            }

            PageSize = PageSizeStakeholders[0];

            base.OnInitialized();
        }

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("pagination");


            if (Size != Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, "pagination-"));
            }
        }
        #region 方法
        /// <summary>
        /// 导航到首页。
        /// </summary>
        public Task NavigateToFirst() => ChangeCurrentPage(1);

        /// <summary>
        /// 导航到上一页。
        /// </summary>
        public async Task NavigateToPrevious()
        {
            if (CurrentPage <= 1)
            {
                CurrentPage = 1;
            }
            else
            {
                CurrentPage--;
            }
            await ChangeCurrentPage(CurrentPage);
        }

        /// <summary>
        /// 导航到下一页。
        /// </summary>
        public async Task NavigateToNext()
        {
            if (CurrentPage >= TotalPages)
            {
                CurrentPage = TotalPages;
            }
            else
            {
                CurrentPage++;
            }
           await ChangeCurrentPage(CurrentPage);
        }

        /// <summary>
        /// 导航到末页。
        /// </summary>
        public Task NavigateToLast() => ChangeCurrentPage(TotalPages);

        /// <summary>
        /// 导航到自定义页。
        /// </summary>
        /// <param name="page">要导航的页。</param>
        public Task NavigateToPage(int page) => ChangeCurrentPage(page);

        /// <summary>
        /// 变更当前分页的页码，并触发 <see cref="CurrentPageChanged"/> 事件。
        /// </summary>
        /// <param name="page">要设置的分页页码。</param>
        public async Task ChangeCurrentPage(int page)
        {
            CurrentPage = page;
            await CurrentPageChanged.InvokeAsync(page);
        }

        /// <summary>
        /// 变更每页的呈现的数据，并触发 <see cref="PageSizeChanged"/> 事件。
        /// </summary>
        /// <param name="size">每页呈现的数据。</param>
        public async Task ChangePageSize(int size)
        {
            await NavigateToFirst();
            PageSize = size;
            await PageSizeChanged.InvokeAsync(size);
        }

        /// <summary>
        /// 选择每页呈现的数据量选项。
        /// </summary>
        /// <param name="selectedItem">选择的项。</param>
        public async Task SelectPageSize(object selectedItem)
        {
            if (!int.TryParse(selectedItem.ToString(), out int size))
            {
                size = PageSizeStakeholders[0];
            }

            await ChangePageSize(size);
        }

        /// <summary>
        /// 变更分页的总记录数，并触发 <see cref="TotalCountChanged"/> 事件。
        /// </summary>
        /// <param name="count">要变更的总记录数。</param>
        public async Task ChangeTotalCount(int count)
        {
            await NavigateToFirst();
            TotalCount = count;
            await TotalCountChanged.InvokeAsync(count);
        }

        /// <summary>
        /// 计算分页数字并返回开始和结束的索引。
        /// </summary>
        public (int start,int end) ComputePageNumber()
        {
            var start = 0;
            var end = 0;

            var middle = PageNumberCount / 2;
            if (CurrentPage <= middle)
            {
                start = 1;
                end = PageNumberCount;
            }
            else if (CurrentPage > middle)
            {
                start = CurrentPage - middle;
                end = CurrentPage + middle;
            }
            if (end > TotalPages)
            {
                end = TotalPages;
                if (start + end != PageNumberCount-2)
                {
                    start = end - PageNumberCount + 2-1;
                }
            }
            if (end <= PageNumberCount)
            {
                start = 1;
            }

            return (start, end);
        }
        #endregion
    }
}
