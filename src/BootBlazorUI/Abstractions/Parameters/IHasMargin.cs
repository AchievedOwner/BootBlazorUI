namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的外边距参数。
    /// </summary>
    public interface IHasMargin : IHasParameter
    {
        /// <summary>
        /// 相对于元素外边距。
        /// </summary>
        public int? Margin { get; set; }
        /// <summary>
        /// 相对于顶部元素的外边距。
        /// </summary>
        public int? MarginTop { get; set; }
        /// <summary>
        /// 相对于底部元素的外边距。
        /// </summary>
        public int? MarginBottom { get; set; }

        /// <summary>
        /// 相对于左侧元素的外边距。
        /// </summary>
        public int? MarginLeft { get; set; }

        /// <summary>
        /// 相对于右侧元素的外边距。
        /// </summary>
        public int? MarginRight { get; set; }
    }
}
