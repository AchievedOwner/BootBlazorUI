using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 表示自定义模板的列。
    /// </summary>
    public class BootDataGridTemplateColumn : BootDataGridColumnBase
    {
        /// <summary>
        /// 设置模板的自定义内容。
        /// </summary>
        [Parameter]
        public RenderFragment<BootDataGridRowSelectedEventArgs> ChildContent { get; set; }
    }
}
