namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的文本颜色。
    /// </summary>
    public interface IHasTextColor : IHasParameter
    {
        /// <summary>
        /// 设置组件的文本颜色。
        /// </summary>
        public TextColor? TextColor { get; set; }
    }
}
