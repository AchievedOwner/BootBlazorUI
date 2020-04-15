using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace BootBlazorUI
{
    using Forms;
    /// <summary>
    /// 呈现 button 的按钮元素。可配合 <see cref="BootEditForm"/> 组件可实现表单验证和提交的交互模式。
    /// </summary>
    public class BootButton : BootComponentBase
    {
        private readonly Func<Task> _handleSubmitDelegate;

        /// <summary>
        /// 初始化 <see cref="BootButton"/> 类的新实例。
        /// </summary>
        public BootButton()
        {
            _handleSubmitDelegate = Submit;
        }

        #region 参数
        /// <summary>
        /// 设置为块状显示，独占一行。
        /// </summary>
        [Parameter]
        public bool Blocked { get; set; }

        /// <summary>
        /// 设置按钮的主题配色。默认是 <see cref="Color.Primary"/>。
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// 设置按钮的尺寸。
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置按钮的类型。默认是 <see cref="ButtonType.Button"/>
        /// </summary>
        [Parameter]
        public ButtonType Type { get; set; } = ButtonType.Button;

        /// <summary>
        /// 设置一个布尔值，表示呈现为边框样式。
        /// </summary>
        [Parameter]
        public bool Outline { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示按钮呈现为启用状态的样式。
        /// </summary>
        [Parameter]
        public bool Actived { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示按钮呈现为禁用状态的样式。
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// 设置按钮的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 当点击按钮时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        
        /// <summary>
        /// 当按钮被禁用时触发的事件。事件参数表示是否被禁用。<c>true</c> 表示禁用状态，否则是 <c>false</c>。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// 当按钮被激活时触发的事件。事件参数表示是否被激活。<c>true</c> 表示禁用状态，否则是 <c>false</c>。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnActived { get; set; }

        /// <summary>
        /// 设置对表单进行编辑监听的上下文。
        /// </summary>
        [CascadingParameter]
        internal EditContext CascadedEditContext { get; set; }

        /// <summary>
        /// 设置表单提交时的文本。优先呈现 <see cref="OnSubmitTemplate"/> 的内容。
        /// </summary>
        [Parameter]
        public string OnSubmitText { get; set; } = "提交中...";

        /// <summary>
        /// 设置表单提交时的自定义模板。
        /// </summary>
        [Parameter]
        public RenderFragment OnSubmitTemplate { get; set; }

        /// <summary>
        /// 设置表单未提交时的自定义模板。当设置 <see cref="OnSubmitTemplate"/> 时，才设置该属性。
        /// </summary>
        [Parameter]
        public RenderFragment NonSubmitTemplate { get; set; }

        /// <summary>
        /// 设置当表单验证合法时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnValidSubmit { get; set; }
        /// <summary>
        /// 设置当合法表单提交时的延迟时间，单位是毫秒。
        /// </summary>
        [Parameter]
        public int ValidSubmitDelay { get; set; } = 100;

        /// <summary>
        /// 设置当表单验证不合法时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnInvalidSubmit { get; set; }

        #endregion

        /// <summary>
        /// 获取一个布尔值，表示当前按钮是否处于表单提交中的状态。
        /// </summary>
        public bool IsSubmitting { get; private set; }

        protected override void OnParametersSet()
        {
            if (OnSubmitTemplate != null && NonSubmitTemplate==null)
            {
                throw new InvalidOperationException($"若设置了 {nameof(OnSubmitTemplate)} 属性，则必须要设置 {nameof(NonSubmitTemplate)} 来代替 {nameof(ChildContent)} 属性");
            }
        }

        #region BuildRenderTree
        /// <summary>
        /// 构建按钮的 DOM 树形结构。
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "button");
            AddIdAttribute(builder, 1);
            builder.AddAttribute(2, "type", $"{Type.ToString().ToLower()}");
            builder.AddAttribute(3, "disabled", Disabled);
            AddCssClassAttribute(builder, 4);
            AddStyleAttribute(builder, 5);
            AddAddtionalAttributes(builder, 6);

            if (CascadedEditContext == null)
            {
                if (OnClick.HasDelegate)
                {
                    builder.AddAttribute(7, "onclick", OnClick);
                }
            }
            else
            {
                builder.AddAttribute(7, "onclick", _handleSubmitDelegate);
            }

            if (IsSubmitting)
            {
                if (OnSubmitTemplate == null)
                {
                    builder.AddContent(8, content=>
                    {
                        content.OpenComponent<BootSpinner>(12);
                        content.AddAttribute(13, nameof(Size), Size.SM);
                        content.AddAttribute(14, nameof(AdditionalCssClass), "mr-1");
                        content.CloseComponent();
                        content.AddContent(15, OnSubmitText);
                    });
                }
                else
                {
                    builder.AddContent(8, OnSubmitTemplate);
                }
            }
            else
            {
                if (OnSubmitTemplate != null)
                {
                    builder.AddContent(8, NonSubmitTemplate);
                }
                else
                {
                    builder.AddContent(8, ChildContent);
                }
            }


            builder.CloseElement();
        }
        #endregion

        /// <summary>
        /// 构建按钮的 class 名称。
        /// </summary>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("btn");

            if (Blocked)
            {
                collection.Add("btn-block");
            }

            collection.Add(string.Format(" btn{0}-{1}", (Outline ? "-outline" : string.Empty), ComponentUtil.GetColorCssClass(Color)));
            if (Size != Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, "btn-"));
            }

            if (Actived)
            {
                collection.Add("active");
            }
        }

        /// <summary>
        /// 禁用按钮的状态。
        /// </summary>
        /// <param name="disabled">是否禁用按钮。</param>
        public async Task Disable(bool disabled = true)
        {
            Disabled = disabled;
            await OnDisabled.InvokeAsync(disabled);
        }
        /// <summary>
        /// 激活按钮的状态。
        /// </summary>
        /// <param name="actived">是否激活按钮。</param>
        public async Task Active(bool actived = true)
        {
            Actived = actived;
            await OnActived.InvokeAsync(actived);
        }

        /// <summary>
        /// 提交指定 <see cref="CascadedEditContext"/> 的表单。
        /// </summary>
        public async Task Submit()
        {
            if (CascadedEditContext == null)
            {
                throw new InvalidOperationException($"未设置 {nameof(CascadedEditContext)} 的表单，无法进行提交，请使用 {nameof(OnClick)} 触发点击按钮的事件。");
            }

            var valid = CascadedEditContext.Validate();

            if (valid)
            {
                IsSubmitting = true;
                await Disable();

                await Task.Delay(ValidSubmitDelay);
                await OnValidSubmit.InvokeAsync(CascadedEditContext);

                IsSubmitting = false;
                await Disable(false);
            }
            else
            {
                await OnInvalidSubmit.InvokeAsync(CascadedEditContext);
            }
        }

        /// <summary>
        /// 表示按钮的类型。
        /// </summary>
        public enum ButtonType
        {
            /// <summary>
            /// 普通的按钮。
            /// </summary>
            Button,
            /// <summary>
            /// 表单提交的按钮。
            /// </summary>
            Submit,
            /// <summary>
            /// 表单重置按钮。
            /// </summary>
            Reset
        }
    }
}
