using System;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 表示当参数的布尔值为 <c>false</c> 需要应用的 css 名称。
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class FalseCssClassAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullCssClassAttribute"/> class.
        /// </summary>
        public FalseCssClassAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 获取样式名称。
        /// </summary>
        public string Name { get; }
    }
}
