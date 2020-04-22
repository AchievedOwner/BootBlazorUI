using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示 Boot 组件的基类。这是一个抽象类。
    /// </summary>
    public abstract class BootComponentBase : ComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BootComponentBase"/> 类的新实例。
        /// </summary>
        protected BootComponentBase()
        {
        }

        /// <summary>
        /// 设置元素或控件的其他 css 的类名称。将在元素使用原生的 class 的基础上进行追加该属性的值。
        /// </summary>
        [Parameter]
        public virtual string AdditionalCssClass { get; set; }

        /// <summary>
        /// 设置元素或控件的 style 属性的值。将在元素使用原生的 style 的基础上进行追加该属性的值。
        /// </summary>
        [Parameter]
        public virtual string AdditionalStyle { get; set; }

        /// <summary>
        /// 设置 css 类名称，并覆盖组件生成的 css 类名称。
        /// </summary>
        [Parameter]
        public string OverrideCssClass { get; set; }

        /// <summary>
        /// 设置 style 的值，并覆盖组件生成的 style 的值。
        /// </summary>
        [Parameter]
        public string OverrideStyles { get; set; }

        /// <summary>
        /// 设置组件的 Id。
        /// </summary>
        [Parameter]
        public virtual string Id { get; set; }

        /// <summary>
        /// 设置将该控件或元素中出现的属性进行合并。
        /// </summary>
        [Parameter(CaptureUnmatchedValues =true)]
        public virtual IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

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
        /// <para>
        /// 若不设置了 <see cref="OverrideCssClass"/> 属性，在会调用 <see cref="CreateComponentCssClass"/> 方法构造组件内部的 css 名称。
        /// </para>
        /// </summary>
        /// <returns>用空格分割的样式字符串。</returns>
        public string BuildCssClassString()
        {
            if (string.IsNullOrWhiteSpace(OverrideCssClass))
            {
                var collection = new List<string>();
                CreateComponentCssClass(collection);
                if (!string.IsNullOrWhiteSpace(AdditionalCssClass))
                {
                    collection.Add(AdditionalCssClass);
                }

                if (!collection.Any())
                {
                    return null;
                }
                return string.Join(" ", collection);
            }

            return OverrideCssClass;
        }

        /// <summary>
        /// 构造组件的 style 的值并用“;”连接。包括 <see cref="CreateComponentStyle(ICollection{string})"/>方法的运算 和 <see cref="AdditionalStyle"/> 属性的值。
        /// <para>
        /// 若不设置了 <see cref="OverrideStyles"/> 属性，在会调用 <see cref="CreateComponentStyle"/> 方法构造组件内部的 style 。
        /// </para>
        /// </summary>
        /// <returns>用分号隔开的 style 样式。</returns>
        public string BuildStylesString()
        {
            if (string.IsNullOrEmpty(OverrideStyles))
            {
                var collection = new List<string>();
                CreateComponentStyle(collection);
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
            return OverrideStyles;
        }
        #region 子类用的方法定义

        /// <summary>
        /// 添加在 <see cref="RenderTreeBuilder"/> 中构造元素的 class 属性。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
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
        protected virtual void AddStyleAttribute(RenderTreeBuilder builder,int sequence=999991)
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
        protected virtual void AddAddtionalAttributes(RenderTreeBuilder builder,int sequence=99992)
        {
            builder.AddMultipleAttributes(sequence, AdditionalAttributes);
        }

        /// <summary>
        /// 添加在 <see cref="RenderTreeBuilder"/> 中构造元素的 Id 属性。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        protected virtual void AddIdAttribute(RenderTreeBuilder builder,int sequence=99994)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                builder.AddAttribute(sequence, "id", Id);
            }
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
            AddIdAttribute(builder);
        }
        #endregion
    }
}
