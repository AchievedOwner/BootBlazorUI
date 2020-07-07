namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的溢出参数。
    /// </summary>
    public interface IHasOverflow
    {
        /// <summary>
        /// 设置组件在内容溢出时的配置。
        /// </summary>
        public Overflow? Overflow { get; set; }

        /// <summary>
        /// 设置组件横向的内容溢出时的配置。
        /// </summary>
        public OverflowStyle? OverflowX { get; set; }
        /// <summary>
        /// 设置组件纵向的内容溢出时的配置。
        /// </summary>
        public OverflowStyle? OverflowY { get; set; }
    }
}
