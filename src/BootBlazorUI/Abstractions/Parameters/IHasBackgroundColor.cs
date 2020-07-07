namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的背景颜色。
    /// </summary>
    public interface IHasBackgroundColor : IHasParameter
    {
        /// <summary>
        /// 设置组件的背景颜色。
        /// </summary>
        public BgColor? BgColor { get; set; }
    }
}
