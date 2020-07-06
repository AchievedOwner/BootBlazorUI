namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件边框显示的参数。
    /// </summary>
    public interface IHasBorder : IHasParameter
    {
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的边框。
        /// </summary>
        /// <value>显示边框则为 <c>true</c>；否则为 <c>false</c>。</value>
        public bool? Border { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的顶部边框。
        /// </summary>
        /// <value>显示边框则为 <c>true</c>；否则为 <c>false</c>。</value>
        public bool? BorderTop { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的底部边框。
        /// </summary>
        /// <value>显示边框则为 <c>true</c>；否则为 <c>false</c>。</value>
        public bool? BorderBottom { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的左侧边框。
        /// </summary>
        /// <value>显示边框则为 <c>true</c>；否则为 <c>false</c>。</value>
        public bool? BorderLeft { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示是否显示组件的右侧边框。
        /// </summary>
        /// <value>显示边框则为 <c>true</c>；否则为 <c>false</c>。</value>
        public bool? BorderRight { get; set; }
        /// <summary>
        /// 设置边框的颜色。
        /// </summary>
        public Color? BorderColor { get; set; }

    }
}
