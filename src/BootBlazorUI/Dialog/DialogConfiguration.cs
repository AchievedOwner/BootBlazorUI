namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 对话框的全局配置。
    /// </summary>
    public class DialogConfiguration
    {
        /// <summary>
        /// 获取或设置对话框确定按钮的文本。
        /// </summary>
        public string ConfirmText { get; set; } = "确定";
        /// <summary>
        /// 获取或设置【确定】按钮的主题颜色。
        /// </summary>
        public Color ConfirmColor { get; set; } = Color.Primary;
        /// <summary>
        /// 获取或设置【确定】按钮的尺寸。
        /// </summary>
        public Size? ConfirmSize { get; set; }

        /// <summary>
        /// 获取或设置对话框取消按钮的文本。
        /// </summary>
        public string CancelText { get; set; } = "取消";
        /// <summary>
        /// 获取或设置【取消】按钮的主题颜色。
        /// </summary>
        public Color CancelColor { get; set; } = Color.Light;
        /// <summary>
        /// 获取或设置【取消】按钮的尺寸。
        /// </summary>
        public Size? CancelSize { get; set; }
    }
}
