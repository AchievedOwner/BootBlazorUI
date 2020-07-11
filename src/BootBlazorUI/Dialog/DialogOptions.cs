using System;

namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 表示对话框的配置。
    /// </summary>
    public class DialogOptions
    {
        /// <summary>
        /// 获取或设置对话框的标题。
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 获取或设置对话框显示的消息。
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置对话框的类型。
        /// </summary>
        public DialogType Type { get; set; } = DialogType.Alert;

        /// <summary>
        /// 获取或设置对话框确定按钮的文本。
        /// </summary>
        public string ConfirmText { get; set; }
        /// <summary>
        /// 获取或设置【确定】按钮的主题颜色。
        /// </summary>
        public Color? ConfirmColor { get; set; } 
        /// <summary>
        /// 获取或设置【确定】按钮的尺寸。
        /// </summary>
        public Size? ConfirmSize { get; set; }

        /// <summary>
        /// 获取或设置对话框取消按钮的文本。
        /// </summary>
        public string CancelText { get; set; }
        /// <summary>
        /// 获取或设置【取消】按钮的主题颜色。
        /// </summary>
        public Color? CancelColor { get; set; }
        /// <summary>
        /// 获取或设置【取消】按钮的尺寸。
        /// </summary>
        public Size? CancelSize { get; set; }

        /// <summary>
        /// 获取或设置当点击【确定】按钮后的方法。
        /// </summary>
        public Action<object> Confirm { get; set; }

        /// <summary>
        /// 获取或设置点击【取消】按钮后的方法。
        /// </summary>
        public Action Cancel { get; set; }
    }
}
