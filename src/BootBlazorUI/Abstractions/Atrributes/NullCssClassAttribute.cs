using System;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 表示当参数是 null 时需要应用的指定样式。
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class NullCssClassAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullCssClassAttribute"/> class.
        /// </summary>
        public NullCssClassAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 获取样式名称。
        /// </summary>
        public string Name { get; }
    }
}
