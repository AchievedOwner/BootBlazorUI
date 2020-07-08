using System;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 定义参数在渲染时的元素属性名称并将参数的值作为元素属性的值。
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ElementAttrAttribute : Attribute
    {
        /// <summary>
        /// 使用当前参数的名称作为元素属性的名称初始化 <see cref="ElementAttrAttribute"/> 类的新实例。
        /// </summary>
        public ElementAttrAttribute() : this(null)
        {

        }
        /// <summary>
        /// 使用指定名称作为元素属性的名称初始化 <see cref="ElementAttrAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="name">元素属性的名称。</param>
        public ElementAttrAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 获取元素的属性名称。
        /// </summary>
        public string Name { get; }
    }
}
