using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
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
        private const string DateFormat = "yyyy-MM-dd"; // Compatible with HTML date inputs
        protected override void OnInitialized()
        {
            if(typeof(TValue)!=typeof(DateTime) && typeof(TValue) != typeof(DateTimeOffset))
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

        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence, "type", "date");
        }

        protected override void BuildValueBindingAttribute(RenderTreeBuilder builder, int sequence)
        => builder.AddAttribute(sequence++, "value", BindConverter.FormatValue(CurrentValueAsString));

        protected override EventCallback<ChangeEventArgs> BuildChangeEventCallback()
        => EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString, CultureInfo.InvariantCulture);

        protected override string OpenElement()
        => "input";

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

        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("form-control");
            if(Size!= Size.Default)
            {
                collection.Add(ComponentUtil.GetSizeCssClass(Size, "form-control-"));
            }
        }

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
