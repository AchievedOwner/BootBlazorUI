using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 表示 Boot 组件的基类，它包含了公共的参数。这是一个抽象类。
    /// </summary>
    public abstract class BootComponentBase : BootComponentParameterBase, IBootComponent
    {
        /// <summary>
        /// 初始化 <see cref="BootComponentBase"/> 类的新实例。
        /// </summary>
        protected BootComponentBase()
        {
        }

        #region 参数
        /// <summary>
        /// 设置元素或控件的其他 css 的类名称。将在元素使用原生的 class 的基础上进行追加该属性的值。
        /// </summary>
        [Parameter]public string AdditionalCssClass { get; set; }

        /// <summary>
        /// 设置元素或控件的 style 属性的值。将在元素使用原生的 style 的基础上进行追加该属性的值。
        /// </summary>
        [Parameter]public string AdditionalStyle { get; set; }

        /// <summary>
        /// 设置将该控件或元素中出现的属性进行合并。
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();
        
        #endregion


        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected virtual void CreateComponentCssClass(ICollection<string> collection) { }

        /// <summary>
        /// 创建组件所需要的 style 样式。
        /// </summary>
        /// <param name="collection">style 名称集合。</param>
        protected virtual void CreateComponentStyle(ICollection<string> collection) { }

        /// <summary>
        /// 构造组件的 class 样式名称并用空格连接的字符串。包括 <see cref="CreateComponentCssClass(ICollection{string})"/>方法的运算 和 <see cref="AdditionalCssClass"/> 属性的值。
        /// </summary>
        /// <returns>用空格分割的样式字符串。</returns>
        public string BuildCssClassString()
        {
            if (AdditionalAttributes.TryGetValue("class", out object cssClass))
            {
                return cssClass.ToString();
            }

            var classList = new List<string>();
            
            CreateComponentCssClass(classList);
            classList.AddRange(this.GetParameterClass());

            if (!string.IsNullOrWhiteSpace(AdditionalCssClass))
            {
                classList.Add(AdditionalCssClass);
            }

            if (!classList.Any())
            {
                return null;
            }
            return string.Join(" ", classList);
        }

        /// <summary>
        /// 构造组件的 style 的值并用“;”连接。包括 <see cref="CreateComponentStyle(ICollection{string})"/>方法的运算 和 <see cref="AdditionalStyle"/> 属性的值。
        /// </summary>
        /// <returns>用分号隔开的 style 样式。</returns>
        public string BuildStylesString()
        {
            if (AdditionalAttributes.TryGetValue("style", out object style))
            {
                return style.ToString();
            }

            var collection = new List<string>();

            CreateComponentStyle(collection);
            collection.AddRange(GetParameterStyle());

            if (!string.IsNullOrWhiteSpace(AdditionalStyle))
            {
                collection.Add(AdditionalStyle);
            }

            if (!collection.Any())
            {
                return null;
            }
            return string.Join(";", collection);
        }
        #region 子类用的方法定义

        /// <summary>
        /// 添加在 <see cref="RenderTreeBuilder"/> 中构造元素的 class 属性。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        /// <param name="sequence">系列号。</param>
        protected virtual void AddCssClassAttribute(RenderTreeBuilder builder, int sequence = 999990)
        {
            var cssClass = BuildCssClassString();
            if (!string.IsNullOrEmpty(cssClass))
            {
                builder.AddAttribute(sequence, "class", cssClass);
            }
        }

        /// <summary>
        /// 添加在 <see cref="RenderTreeBuilder"/> 中构造元素的 style 属性。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        /// <param name="sequence">系列号。</param>
        protected virtual void AddStyleAttribute(RenderTreeBuilder builder, int sequence = 999991)
        {
            var styles = BuildStylesString();
            if (!string.IsNullOrEmpty(styles))
            {
                builder.AddAttribute(sequence, "style", styles);
            }
        }

        /// <summary>
        /// 添加在 <see cref="RenderTreeBuilder"/> 中构造元素未被明确定义的其他属性。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        /// <param name="sequence">系列号。</param>
        protected virtual void AddAddtionalAttributes(RenderTreeBuilder builder, int sequence = 99992)
        {
            builder.AddMultipleAttributes(sequence, AdditionalAttributes);
        }

        /// <summary>
        /// 添加构造 <see cref="RenderTreeBuilder"/> 的公共的属性，包括 class、style、id 和 AdditionalAttributes。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        protected virtual void AddCommonAttributes(RenderTreeBuilder builder)
        {
            AddCssClassAttribute(builder);
            AddStyleAttribute(builder);
            AddAddtionalAttributes(builder);
        }
        #endregion
    }
}
