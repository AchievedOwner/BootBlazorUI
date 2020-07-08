namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 设置组件的标题参数。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasParameter" />
    public interface IHasTitle : IHasParameter
    {
        /// <summary>
        /// 设置组件在鼠标悬停后显示的标题内容。
        /// </summary>
        public string Title { get; set; }
    }
}
