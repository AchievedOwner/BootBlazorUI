using System;
using System.Collections.Generic;
using System.Globalization;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现支持 <see cref="DateTime"/> 或 <see cref="DateTimeOffset"/> 类型的 type="date" 元素的日期组件。
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class BootInputDate<TValue> : BootInputBase<TValue>
    {
        /// <summary>
        /// The date format
        /// </summary>
        private const string DateFormat = "yyyy-MM-dd"; // Compatible with HTML date inputs        
        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="ArgumentException">仅支持 DateTime 和 DateTimeOffset 的数据类型</exception>
        protected override void OnInitialized()
        {
            if (typeof(TValue) != typeof(DateTime) && typeof(TValue) != typeof(DateTimeOffset))
            {
                throw new ArgumentException("仅支持 DateTime 和 DateTimeOffset 的数据类型");
            }

            base.OnInitialized();
        }

        /// <summary>
        /// 设置组件的尺寸。
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Default;
        /// <summary>
        /// 构造输入组件的渲染树。
        /// </summary>
        /// <param name="builder">渲染构造器。</param>
        /// <param name="sequence">系列。</param>
        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence, "type", "date");
        }
        /// <summary>
        /// 构造值绑定的特性，默认使用 <see cref="T:Microsoft.AspNetCore.Components.BindConverter" /> 类型。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        protected override void BuildValueBindingAttribute(RenderTreeBuilder builder, int sequence)
        => builder.AddAttribute(sequence++, "value", BindConverter.FormatValue(CurrentValueAsString));
        /// <summary>
        /// 构造 <see cref="T:Microsoft.AspNetCore.Components.EventCallback`1" /> 的双向绑定事件。
        /// </summary>
        /// <returns></returns>
        protected override EventCallback<ChangeEventArgs> BuildChangeEventCallback()
        => EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString, CultureInfo.InvariantCulture);
        /// <summary>
        /// 定义组件的元素名称。
        /// </summary>
        /// <returns>
        /// 组件元素的名称字符串。
        /// </returns>
        protected override string OpenElement()
        => "input";
        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="P:Microsoft.AspNetCore.Components.Forms.InputBase`1.CurrentValueAsString" />.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>
        /// A string representation of the value.
        /// </returns>
        protected override string FormatValueAsString(TValue value)
        {
            switch (value)
            {
                case DateTime dateTimeValue:
                    return BindConverter.FormatValue(dateTimeValue, DateFormat, CultureInfo.InvariantCulture);
                case DateTimeOffset dateTimeOffsetValue:
                    return BindConverter.FormatValue(dateTimeOffsetValue, DateFormat, CultureInfo.InvariantCulture);
                default:
                    return string.Empty; // Handles null for Nullable<DateTime>, etc.
            }
        }
        /// <summary>
        /// 尝试转换指定值为字符串。
        /// </summary>
        /// <param name="value">输入控件的值。</param>
        /// <param name="result">转换后的值。</param>
        /// <param name="validationErrorMessage">转换失败时的错误字符串。</param>
        /// <returns>
        /// 转换成功返回 <c>true</c>；否则返回 <c>false</c>。
        /// </returns>
        /// <exception cref="InvalidOperationException">类型 '{targetType}' 不是一个受日期类型支持的数据类型</exception>
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

            bool success;
            if (targetType == typeof(DateTime))
            {
                success = TryParseDateTime(value, out result);
            }
            else if (targetType == typeof(DateTimeOffset))
            {
                success = TryParseDateTimeOffset(value, out result);
            }
            else
            {
                throw new InvalidOperationException($"类型 '{targetType}' 不是一个受日期类型支持的数据类型");
            }

            if (success)
            {
                validationErrorMessage = null;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
                return false;
            }
        }
        /// <summary>
        /// 构建组件内置的 class 样式。
        /// </summary>
        /// <param name="collection"></param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("form-control");
            if (Size != Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, "form-control-"));
            }
        }
        /// <summary>
        /// Tries the parse date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        static bool TryParseDateTime(string value, out TValue result)
        {
            var success = BindConverter.TryConvertToDateTime(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
            if (success)
            {
                result = (TValue)(object)parsedValue;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
        /// <summary>
        /// Tries the parse date time offset.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        static bool TryParseDateTimeOffset(string value, out TValue result)
        {
            var success = BindConverter.TryConvertToDateTimeOffset(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
            if (success)
            {
                result = (TValue)(object)parsedValue;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
