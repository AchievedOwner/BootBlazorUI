using System;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 表示选择行的事件参数。
    /// </summary>
    public class BootDataGridRowSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化 <see cref="BootDataGridRowSelectedEventArgs"/> 类的新实例。
        /// </summary>
        /// <param name="index">选择行的索引。</param>
        /// <param name="item">选项的行数据。</param>
        public BootDataGridRowSelectedEventArgs(int index, object item)
        {
            Item = item;
            Index = index;
        }

        /// <summary>
        /// 获取选择行的数据。
        /// </summary>
        public object Item { get; }
        /// <summary>
        /// 获取选择行的索引。
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 提供不选择任何行的 <see cref="BootDataGridRowSelectedEventArgs"/> 事件参数的值。
        /// </summary>
        public static readonly new BootDataGridRowSelectedEventArgs Empty = new BootDataGridRowSelectedEventArgs(-1, null);
    }
}
