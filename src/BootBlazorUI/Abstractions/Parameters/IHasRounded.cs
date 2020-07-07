namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 设置组件具有边框圆角的参数。
    /// </summary>
    public interface IHasRounded
    {
        /// <summary>
        /// 设置组件四个角都是圆角。
        /// </summary>
        public bool? Rounded { get; set; }
        /// <summary>
        /// 设置组件顶部呈现圆角。
        /// </summary>
        public bool? RoundedTop { get; set; }
        /// <summary>
        /// 设置组件底部呈现圆角。
        /// </summary>
        public bool? RoundedBottom { get; set; }
        /// <summary>
        /// 设置组件左侧呈现圆角。
        /// </summary>
        public bool? RoundedLeft { get; set; }
        /// <summary>
        /// 设置组件右侧呈现圆角。
        /// </summary>
        public bool? RoundedRight { get; set; }
        /// <summary>
        /// 设置组件呈现圆形。
        /// </summary>
        public bool? RoundedCircle { get; set; }
        /// <summary>
        /// 设置组件呈现椭圆。
        /// </summary>
        public bool? RoundedPill { get; set; }
    }
}
