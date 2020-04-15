using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 div 的元素并且带有警告消息框的组件。
    /// </summary>
    public class BootAlert : BootComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BootAlert"/> 类的新实例。
        /// </summary>
        public BootAlert()
        {

        }

        /// <summary>
        /// 设置消息框的主题颜色。默认是 <see cref="Color.Primary"/>。
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// 设置消息框的任意内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在右侧显示一个关闭的“X”按钮，点击后则会隐藏该警告框。
        /// </summary>
        [Parameter]
        public bool Dismisable { get; set; }

        /// <summary>
        /// 获取一个布尔值，表示消息框的是否为显示状态。默认是 <c>true</c>。
        /// </summary>
        public bool IsShown { get; private set; } = true;

        /// <summary>
        /// 设置警告消息框显示前触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnShown { get; set; }

        /// <summary>
        /// 设置警告消息框隐藏前触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnHidden { get; set; }

        /// <summary>
        /// 显示当前警告消息框。
        /// </summary>
        public async Task Show()
        {
            IsShown = true;
            await OnShown.InvokeAsync(IsShown);
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏当前警告消息框。
        /// </summary>
        public async Task Hide()
        {
            IsShown = false;
            await OnHidden.InvokeAsync(IsShown);
            StateHasChanged();
        }

        /// <summary>
        /// 创建 alert 元素的 css 的名称。
        /// </summary>
        /// <param name="collection">样式集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("alert");
            collection.Add(ComponentUtil.GetColorCssClass(Color, "alert-"));
            collection.Add("fade");
            if (IsShown)
            {
                collection.Add("show");
            }

            if (Dismisable)
            {
                collection.Add("alert-dismissible");
            }
        }
        /// <summary>
        /// 构造组件树。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);

            builder.AddContent(1, ChildContent);
            if (Dismisable)
            {
                builder.AddContent(2, child =>
                {
                    child.OpenElement(3, "button");
                    child.AddAttribute(4, "type", "button");
                    child.AddAttribute(5, "class", "close");
                    child.AddAttribute(6, "onclick", EventCallback.Factory.Create(this, () => Hide()));
                    child.AddMarkupContent(7, "<span aria-hidden=\"true\">&times;</span>");
                    child.CloseElement();
                });
            }
            builder.CloseElement();
        }
    }
}
