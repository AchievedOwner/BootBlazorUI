namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的内边距参数。
    /// </summary>
    public interface IHasPadding : IHasParameter
    {
        /// <summary>
        /// 相对于元素内边距。
        /// </summary>
        public int? Padding { get; set; }
        /// <summary>
        /// 相对于顶部元素的内边距。
        /// </summary>
        public int? PaddingTop { get; set; }
        /// <summary>
        /// 相对于底部元素的内边距。
        /// </summary>
        public int? PaddingBottom { get; set; }

        /// <summary>
        /// 相对于左侧元素的内边距。
        /// </summary>
        public int? PaddingLeft { get; set; }

        /// <summary>
        /// 相对于右侧元素的内边距。
        /// </summary>
        public int? PaddingRight { get; set; }
    }
}
