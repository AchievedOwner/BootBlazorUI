using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 表示组件拥有公共参数的基类。这是一个抽象类。
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    /// <seealso cref="BootBlazorUI.Abstractions.IBootComponentParameters" />
    public abstract class BootComponentParameterBase : ComponentBase, IBootComponentParameters
    {
        /// <summary>
        /// 设置组件的宽度百分比，<c>null</c> 表示不使用宽度百分比。
        /// </summary>
        /// <value>
        ///   <see cref="BootBlazorUI.Width" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] public Width? Width { get; set; }
        /// <summary>
        /// 设置组件的文本颜色。
        /// </summary>
        /// <value>
        ///   <see cref="Color" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] [CssClass("text-")] public Color? TextColor { get; set; }
        /// <summary>
        /// 设置组件的背景颜色。
        /// </summary>
        /// <value>
        ///   <see cref="Color" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] [CssClass("bg-")] public Color? BackgroundColor { get; set; }
        /// <summary>
        /// 设置文本在组件中的水平对齐方式。
        /// </summary>
        /// <value>
        ///   <see cref="HorizontalAlignment" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] [CssClass("text-")] public HorizontalAlignment? TextAlign { get; set; }
        /// <summary>
        /// 相对于元素外边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("m-")] public int? Margin { get; set; }
        /// <summary>
        /// 相对于顶部元素的外边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("mt-")] public int? MarginTop { get; set; }
        /// <summary>
        /// 相对于底部元素的外边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("mb-")] public int? MarginBottom { get; set; }
        /// <summary>
        /// 相对于左侧元素的外边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("ml-")] public int? MarginLeft { get; set; }
        /// <summary>
        /// 相对于右侧元素的外边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("mr-")] public int? MarginRight { get; set; }
        /// <summary>
        /// 相对于元素内边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("p-")] public int? Padding { get; set; }
        /// <summary>
        /// 相对于顶部元素的内边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("pt-")] public int? PaddingTop { get; set; }
        /// <summary>
        /// 相对于底部元素的内边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("pb-")] public int? PaddingBottom { get; set; }
        /// <summary>
        /// 相对于左侧元素的内边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("pl-")] public int? PaddingLeft { get; set; }
        /// <summary>
        /// 相对于右侧元素的内边距。值的范围是 1-5、
        /// </summary>
        [Parameter] [CssClass("pr-")] public int? PaddingRight { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter][CssClass("border")]public bool? Border { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的顶部边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter][CssClass("border-top")]public bool? BorderTop { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的底部边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] [CssClass("border-bottom")] public bool? BorderBottom { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的左侧边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] [CssClass("border-left")] public bool? BorderLeft { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的右侧边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] [CssClass("border-right")] public bool? BorderRight { get; set; }
        /// <summary>
        /// 设置边框的颜色。
        /// </summary>
        [Parameter] [CssClass("border-")] public Color? BorderColor { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示清除组件的浮动。
        /// </summary>
        [Parameter] [CssClass("clearfix")] public bool? ClearFix { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示组件使用左浮动。
        /// </summary>
        [Parameter] [CssClass("float-left")] public bool? FloatLeft { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示组件使用右浮动。
        /// </summary>
        [Parameter] [CssClass("float-right")] public bool? FloatRight { get; set; }
        /// <summary>
        /// 设置组件的高度比例。
        /// </summary>
        [Parameter] [CssClass("h-")] public Height? Height { get; set; }

        /// <summary>
        /// 返回所有公用参数的 css 名称列表。
        /// </summary>
        /// <returns></returns>
        public virtual IReadOnlyList<string> GetParameterClass()
        {
            var classList = new List<string>();

            var properties = GetType().GetProperties().Where(m => m.IsDefined(typeof(ParameterAttribute), true) && m.IsDefined(typeof(CssClassAttribute), true));
            foreach (var item in properties)
            {
                var name = item.Name;
                var value = item.GetValue(this);

                var cssClass = item.GetCustomAttribute<CssClassAttribute>()?.Name;

                var nullCssClass = item.GetCustomAttribute<NullCssClassAttribute>();
                if (nullCssClass != null && value == null)
                {
                    classList.Add(nullCssClass.Name);
                }
                else if (value != null)
                {
                    if (value.GetType().BaseType == typeof(Enum))
                    {
                        classList.Add(value.GetEnumCssClass(this, name));
                    }
                    else
                    {
                        if (value.GetType() == typeof(bool))//bool 值转换成 1:true 0:false
                        {
                            value = (bool)value ? null : "-0";
                        }

                        classList.Add($"{cssClass}{value}");
                    }
                }
            }
            return classList;
        }
    }
}
