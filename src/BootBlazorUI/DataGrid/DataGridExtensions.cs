using System;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// DataGrid 扩展。
    /// </summary>
    public static class DataGridExtensions
    {
        /// <summary>
        /// 获取当前行指定数据源绑定字段的值。
        /// </summary>
        /// <param name="row">当前行。</param>
        /// <param name="field">数据源的字段。</param>
        /// <returns>数据源字段在该行的值或 null。</returns>
        public static object GetValue(this object row,string field)
        {
            if (row is null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentException("不能是null或空字符串", nameof(field));
            }

            var rowType = row.GetType();
            object value = default;
            if (rowType.IsClass)//实体
            {
                var property = rowType.GetProperty(field);
                if (property == null)
                {
                    throw new InvalidOperationException($"没有在数据源中找到“{field}”字段");
                }
                value = property.GetValue(row);
            }

            return value;
        }

        /// <summary>
        /// 获取当前行指定数据源绑定字段的值。
        /// </summary>
        /// <typeparam name="T">数据类型。</typeparam>
        /// <param name="row">当前行。</param>
        /// <param name="field">数据源的字段。</param>
        /// <returns>数据源字段在该行的值或 null。</returns>
        public static T GetValue<T>(this object row, string field)
            => (T)GetValue(row, field);
    }
}
