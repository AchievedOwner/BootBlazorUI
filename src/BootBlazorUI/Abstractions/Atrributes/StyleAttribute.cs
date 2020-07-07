using System;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 定义组件参数的 style 类名称。。
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class StyleAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="CssClassAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="name">参数的 style 名称。</param>
        public StyleAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 获取参数的 style 名称。
        /// </summary>
        public string Name { get; }
    }
}
