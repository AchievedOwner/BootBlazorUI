namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件的高度比例的参数。
    /// </summary>
    public interface IHasHeight
    {
        /// <summary>
        /// 设置组件的高度百分比。
        /// </summary>
        public Height? HeightPercent { get; set; }

        /// <summary>
        /// 设置组件的固定高度。
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// 设置组件的最小高度。
        /// </summary>
        public string MinHeight { get; set; }
        /// <summary>
        /// 设置组件的最大高度。
        /// </summary>
        public string MaxHeight { get; set; }
    }
}
