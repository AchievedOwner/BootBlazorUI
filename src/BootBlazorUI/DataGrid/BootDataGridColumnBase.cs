using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    using Abstractions;
    /// <summary>
    /// 表示 DataGrid 列的基类，这是一个抽象类。
    /// </summary>
    public abstract class BootDataGridColumnBase : BootComponentBase
    {
        /// <summary>
        /// 设置列的标题。
        /// </summary>
        [Parameter]
        public string Title { get; set; }


        /// <summary>
        /// 设置单元格的宽度，单位自己决定。如果所有的列都不设置宽度，则会平均分配。
        /// </summary>
        [Parameter]
        public new string Width { get; set; }

        /// <summary>
        /// 设置列的水平对齐方式。默认是左对齐。
        /// </summary>
        [Parameter]
        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Left;

        /// <summary>
        /// 父组件。
        /// </summary>
        [CascadingParameter]
        internal BootDataGrid Parent { get; set; }



        /// <summary>
        /// 获取列的宽度 style 字符串，即 width:xxx
        /// </summary>
        internal string GetWidthStyleString()
        {
            if (!string.IsNullOrWhiteSpace(Width))
            {
                return $"width:{Width}";
            }
            var columnsHasWidthCount = Parent.Columns.Count(m => string.IsNullOrWhiteSpace(m.Width));
            if (columnsHasWidthCount == Parent.Columns.Count)
            {
                return $"width:calc(100%/{columnsHasWidthCount})";
            }
            return null;
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="BootChildNotInParentComponentException{BootDataGrid, BootDataGridFieldColumn}"></exception>
        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new BootChildNotInParentComponentException<BootDataGrid, BootDataGridFieldColumn>();
            }
        }

        /// <summary>
        /// Method invoked after each time the component has been rendered.
        /// </summary>
        /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
        /// on this component instance; otherwise <c>false</c>.</param>
        /// <remarks>
        /// The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
        /// are useful for performing interop, or interacting with values recieved from <c>@ref</c>.
        /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
        /// once.
        /// </remarks>
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Parent.AddColumn(this);
            }
        }



        /// <summary>
        /// 获取列标题。
        /// </summary>
        internal virtual string GetTitle() => Title;

        /// <summary>
        /// 创建组件所需要的 style 样式。
        /// </summary>
        /// <param name="collection">style 名称集合。</param>
        protected override void CreateComponentStyle(ICollection<string> collection)
        {
            var width = GetWidthStyleString();
            if (!string.IsNullOrEmpty(width))
            {
                collection.Add(width);
            }
        }
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add(ComponentUtil.GetHorizontalAlignCssClass(Align, "text-"));
        }
    }
}
