using System;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 定义组件参数的 css 类名称。并会与属性的值合并为 css 的类名称。
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CssClassAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="CssClassAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="name">参数的 css 名称。</param>
        public CssClassAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 获取参数的 css 名称。
        /// </summary>
        public string Name { get; }
    }
}
