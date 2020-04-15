using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现 select 元素的组件，并可以绑定指定的数据类型。
    /// </summary>
    /// <typeparam name="TValue">元素值的类型。</typeparam>
    public class BootInputSelect<TValue> : BootInputBase<TValue>
    {
        /// <summary>
        /// 设置组件的尺寸，默认是 <see cref="Size.Default"/>。
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置 select 组件中的 option 项列表。
        /// </summary>
        [Parameter]
        public IReadOnlyList<BootInputSelectItem> SelectItems { get; set; }

        /// <summary>
        /// 设置用于创建 select 组件中的 option 项列表的委托。若设置值，则会覆盖 <see cref="SelectItems"/> 的值。
        /// </summary>
        [Parameter]
        public Func<IReadOnlyList<BootInputSelectItem>> SelectItemsProvider { get; set; }

        /// <summary>
        /// 返回 select 组件名称。
        /// </summary>
        protected override string OpenElement()
        => "select";

        protected override void OnInitialized()
        {
            if (SelectItems == null && SelectItemsProvider == null)
            {
                throw new InvalidOperationException($"{nameof(SelectItems)} 和 {nameof(SelectItemsProvider)} 必须设置其中一个。");
            }

            if (SelectItemsProvider != null)
            {
                SelectItems = SelectItemsProvider.Invoke();
            }
        }

        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddContent(sequence++, optionBuilder =>
            {
                foreach (var item in SelectItems)
                {
                    optionBuilder.OpenElement(sequence++, "option");
                    optionBuilder.AddAttribute(sequence++, "value", item.Value);
                    if (item.Selected)
                    {
                        optionBuilder.AddAttribute(sequence++, "selected", true);
                    }
                    optionBuilder.AddContent(sequence++, (MarkupString)item.Text);
                    optionBuilder.CloseElement();
                }
            });
        }

       

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("form-control");
            if (Size != Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, "form-control-"));
            }
        }
    }

    /// <summary>
    /// 表示 select 元素的 option 组件。
    /// </summary>
    public class BootInputSelectItem
    {
        /// <summary>
        /// 初始化 <see cref="BootInputSelectItem"/> 类的新实例。
        /// </summary>
        public BootInputSelectItem()
        {

        }

        /// <summary>
        /// 获取或设置 option 元素的 value 值。
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 获取或设置 option 元素显示的文本。
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 获取或设置 option 元素的分组名称。
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 获取或设置一个布尔值，表示 option 元素是否选中。
        /// </summary>
        public bool Selected { get; set; }
    }
}
