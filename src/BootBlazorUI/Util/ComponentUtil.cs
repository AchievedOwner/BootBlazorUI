using System.Linq;

namespace BootBlazorUI
{
    /// <summary>
    /// 组件工具类。
    /// </summary>
    static class ComponentUtil
    {
        /// <summary>
        /// 获取颜色主题的 css 类名称。
        /// </summary>
        /// <param name="color">颜色主题。</param>
        /// <param name="prefix">前缀。</param>
        internal static string GetColorCssClass(Color color,string prefix=default)
            =>$"{prefix}{color.ToString().ToLower()}";

        /// <summary>
        /// 获取尺寸的 css 类名称。
        /// </summary>
        /// <param name="size">尺寸。</param>
        /// <param name="prefix">前缀。</param>
        internal static string GetSizeCssClass(Size size, string prefix = default)
            => $"{prefix}{size.ToString().ToLower()}";

        /// <summary>
        /// 获取 flex 对齐方式。
        /// </summary>
        /// <param name="flex">Flex布局</param>
        /// <param name="prefix">前缀。</param>
        internal static string GetFlexAlignCssClass(Flex flex,string prefix=default)
            => $"{prefix}{flex.ToString().ToLower()}";

        /// <summary>
        /// 获取指定反选颜色的 css 类名称。
        /// </summary>
        /// <param name="color">要反选的颜色。</param>
        /// <param name="prefix">前缀。</param>
        public static string GetReverseColorCssClass(Color color,string prefix=default)
        {
            var reverseColor = color switch
            {
                Color.Light => Color.Dark,
                Color.Warning => Color.Dark,
                _ => Color.Light
            };
            return GetColorCssClass(reverseColor, prefix);
        }
    }
}
