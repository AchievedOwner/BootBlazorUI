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
        /// 设置组件的背景颜色。
        /// </summary>
        /// <value>
        ///   <see cref="Color" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] [CssClass("bg-")] public BgColor? BgColor { get; set; }

        /// <summary>
        /// 设置组件的文本颜色。
        /// </summary>
        /// <value>
        ///   <see cref="Color" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] [CssClass("text-")] public TextColor? TextColor { get; set; }
        /// <summary>
        /// 设置文本在组件中的水平对齐方式。
        /// </summary>
        /// <value>
        ///   <see cref="HorizontalAlignment" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter] [CssClass("text-")] public HorizontalAlignment? TextAlign { get; set; }

        #region Margin
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
        #endregion
        #region Padding
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
        #endregion

        #region Border
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter][CssClass("border")][FalseCssClass("border-0")]public bool? Border { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的顶部边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter][CssClass("border-top")] [FalseCssClass("border-top-0")] public bool? BorderTop { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的底部边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] [CssClass("border-bottom")] [FalseCssClass("border-bottom-0")] public bool? BorderBottom { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的左侧边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] [CssClass("border-left")] [FalseCssClass("border-left-0")] public bool? BorderLeft { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的右侧边框。
        /// </summary>
        /// <value>
        /// 显示边框则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        [Parameter] [CssClass("border-right")] [FalseCssClass("border-right-0")] public bool? BorderRight { get; set; }
        /// <summary>
        /// 设置边框的颜色。
        /// </summary>
        [Parameter] [CssClass("border-")] public Color? BorderColor { get; set; }
        #endregion

        #region Float
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
        #endregion

        #region Overflow
        /// <summary>
        /// 设置组件在内容溢出时的配置。
        /// </summary>
        [Parameter] [CssClass("overflow-")] public Overflow? Overflow { get; set; }
        /// <summary>
        /// 设置组件横向的内容溢出时的配置。
        /// </summary>
        [Parameter] [Style("overflow-x")] public OverflowStyle? OverflowX { get; set; }
        /// <summary>
        /// 设置组件纵向的内容溢出时的配置。
        /// </summary>
        [Parameter] [Style("overflow-y")] public OverflowStyle? OverflowY { get; set; }
        #endregion

        #region Shadow
        /// <summary>
        /// 设置一个布尔值，表示是否在所有的视窗使用阴影。
        /// </summary>
        [Parameter] [CssClass("shadow")][FalseCssClass("shadow-none")] public bool? Shadow { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否在小尺寸的视窗使用阴影。
        /// </summary>
        [Parameter] [CssClass("shadow-sm")] [FalseCssClass("shadow-sm-none")] public bool? ShadowSmall { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否在中等尺寸的视窗使用阴影。
        /// </summary>
        [Parameter] [CssClass("shadow-md")] [FalseCssClass("shadow-md-none")] public bool? ShadowMedium { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否在大尺寸的视窗使用阴影。
        /// </summary>
        [Parameter] [CssClass("shadow-lg")] [FalseCssClass("shadow-lg-none")] public bool? ShadowLarge { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否在超大尺寸的视窗使用阴影。
        /// </summary>
        [Parameter] [CssClass("shadow-xl")] [FalseCssClass("shadow-xl-none")] public bool? ShadowExtraLarge { get; set; }
        #endregion

        #region Width
        /// <summary>
        /// 设置组件的宽度百分比，<c>null</c> 表示不使用宽度百分比。
        /// </summary>
        /// <value>
        ///   <see cref="BootBlazorUI.Width" /> 的枚举值或 <c>null</c>。
        /// </value>
        [Parameter][CssClass("w-")] public Width? WidthPercent { get; set; }
        /// <summary>
        /// 设置组件的固定宽度。
        /// </summary>
        [Parameter][Style("width")]public string Width { get; set; }
        /// <summary>
        /// 设置组件的最大宽度。
        /// </summary>
        [Parameter] [Style("max-width")] public string MaxWidth { get; set; }
        /// <summary>
        /// 设置组件的最小宽度。
        /// </summary>
        [Parameter] [Style("min-width")] public string MinWidth { get; set; }
        #endregion

        #region Height
        /// <summary>
        /// 设置组件的高度比例。
        /// </summary>
        [Parameter] [CssClass("h-")] public Height? HeightPercent { get; set; }
        /// <summary>
        /// 设置组件的固定高度。
        /// </summary>
        [Parameter][Style("height")]public string Height { get; set; }
        /// <summary>
        /// 设置组件的最小高度。
        /// </summary>
        [Parameter] [Style("min-height")] public string MinHeight { get; set; }
        /// <summary>
        /// 设置组件的最大高度。
        /// </summary>
        [Parameter] [Style("max-height")] public string MaxHeight { get; set; }
        #endregion
        #region Rounded        
        /// <summary>
        /// 设置组件四个角都是圆角。
        /// </summary>
        [Parameter][CssClass("rounded")][FalseCssClass("rounded-0")]public bool? Rounded { get; set; }
        /// <summary>
        /// 设置组件顶部呈现圆角。
        /// </summary>
        [Parameter] [CssClass("rounded-top")] public bool? RoundedTop { get; set; }
        /// <summary>
        /// 设置组件底部呈现圆角。
        /// </summary>
        [Parameter] [CssClass("rounded-bottom")] public bool? RoundedBottom { get; set; }
        /// <summary>
        /// 设置组件左侧呈现圆角。
        /// </summary>
        [Parameter] [CssClass("rounded-left")] public bool? RoundedLeft { get; set; }
        /// <summary>
        /// 设置组件右侧呈现圆角。
        /// </summary>
        [Parameter] [CssClass("rounded-right")] public bool? RoundedRight { get; set; }
        /// <summary>
        /// 设置组件呈现圆形。
        /// </summary>
        [Parameter] [CssClass("rounded-circle")] public bool? RoundedCircle { get; set; }
        /// <summary>
        /// 设置组件呈现椭圆。
        /// </summary>
        [Parameter] [CssClass("rounded-pill")] public bool? RoundedPill { get; set; }
        #endregion

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
                        if (value.GetType() == typeof(bool))
                        {
                            var flag = ((bool)value);
                            if (!flag)
                            {
                                var falseAttribute = item.GetCustomAttribute<FalseCssClassAttribute>();
                                cssClass = falseAttribute?.Name;
                            }
                            value = null;
                        }

                        classList.Add($"{cssClass}{value}");
                    }
                }
            }
            return classList;
        }

        /// <summary>
        /// 返回所有公用参数的 style 名称列表。
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<string> GetParameterStyle()
        {
            var list = new List<string>();

            var properties = GetType().GetProperties().Where(m => m.IsDefined(typeof(ParameterAttribute), true) && m.IsDefined(typeof(StyleAttribute), true));
            foreach (var item in properties)
            {
                var value = item.GetValue(this);

                if (value != null)
                {
                    var name = item.GetCustomAttribute<StyleAttribute>()?.Name;
                    if (value.GetType().BaseType == typeof(Enum))
                    {
                        list.Add($"{name}:{value.GetDescription()}");
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            list.Add($"{name}:{value}");
                        }
                    }
                }
            }
            return list;
        }
    }
}
