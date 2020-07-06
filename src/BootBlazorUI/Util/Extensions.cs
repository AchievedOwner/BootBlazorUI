using System;
using System.ComponentModel;
using System.Reflection;

using BootBlazorUI.Abstractions;

namespace BootBlazorUI
{
    /// <summary>
    /// 扩展。
    /// </summary>
    public static class Extensions
    {
		/// <summary>
		/// 获取当前枚举对象的 <see cref="DescriptionAttribute"/> 特性的 Description 字段。
		/// </summary>
		/// <param name="enumeration">被扩展的Enum对象</param>
		/// <returns>若未定义 <see cref="DescriptionAttribute"/> 特性，则返回枚举字段的默认值。否则，返回 <see cref="DescriptionAttribute"/> 的 Description 字段的值。</returns>
		public static string GetDescription(this object enumeration)
		{
			if (enumeration == null)
			{
				return null;
			}

			var enumType = enumeration.GetType();
			var enumName = enumeration.ToString();
			var fieldInfo = enumType.GetTypeInfo().GetDeclaredField(enumeration.ToString());

			var description = enumName;
			if (fieldInfo == null)
			{
				return description;
			}
			if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null)
			{
				description = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
			}
			return description;
		}

        /// <summary>
        /// 获取标记了 <see cref="CssClassAttribute"/> 特性的 <see cref="CssClassAttribute.Name"/> 的值。
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetParameterPrefix(this object component,string propertyName)
        {
			return component.GetType().GetProperty(propertyName)
				.GetCustomAttribute<CssClassAttribute>()?.Name;
        }

		public static string GetEnumCssClass(this object enumeration,object component,string propertyName)
		{
			var prefix = component.GetParameterPrefix(propertyName);
			return $"{prefix}{enumeration.GetDescription()}";
		}
	}
}
