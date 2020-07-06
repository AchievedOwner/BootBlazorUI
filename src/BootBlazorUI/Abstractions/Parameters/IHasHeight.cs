namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的高度比例的参数。
    /// </summary>
    public interface IHasHeight
    {
        /// <summary>
        /// 设置组件的高度比例。
        /// </summary>
        public Height? Height { get; set; }
    }
}
