using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootBlazorUI.DataGrid
{
    partial class BootDataGrid
    {
        /// <summary>
        /// 表示数据表格的列。
        /// </summary>
        internal ICollection<BootDataGridColumnBase> Columns { get; private set; } = new HashSet<BootDataGridColumnBase>();


        /// <summary>
        /// 获取当前页码。
        /// </summary>
        internal int CurrentPage { get; private set; } = 1;

        /// <summary>
        /// 设置数据源。
        /// </summary>
        public IReadOnlyList<object> DataSource { get; private set; }

        /// <summary>
        /// 获取每一行的 css 集合。
        /// </summary>
        internal Dictionary<int, List<string>> RowCssList { get; private set; } = new Dictionary<int, List<string>>();

        /// <summary>
        /// 获取每一行的 style 集合。
        /// </summary>
        internal Dictionary<int, List<string>> RowStyleList { get; private set; } = new Dictionary<int, List<string>>();

        /// <summary>
        /// 获取行的样式。
        /// </summary>
        private string GetRowStyle()
        {
            var collection = new List<string>();

            if (FixRowHeight.HasValue)
            {
                collection.Add($"height:{FixRowHeight.Value}px;overflow-y:scroll");
            }

            return string.Join(";", collection);
        }

        /// <summary>
        /// 添加列。
        /// </summary>
        /// <param name="column">要添加的列。</param>
        internal void AddColumn(BootDataGridColumnBase column)
        {
            if (column is null)
            {
                throw new System.ArgumentNullException(nameof(column));
            }
            Columns.Add(column);
            StateHasChanged();
        }

        int GetColSpan()
        {
            int colSpan = Columns.Count;
            if (RowNumber)
            {
                colSpan++;
            }
            return colSpan;
        }


        /// <summary>
        /// 加载指定页码的分页数据。
        /// </summary>
        /// <param name="page">当前页码。</param>
        async Task LoadPaginationData(int page)
        {
            IsCompleted = false;
            var dataSource = await Task.Run(() => DataBind(page));

            if(!(dataSource is IEnumerable data))
            {
                throw new InvalidOperationException($"数据源必须实现 {nameof(IEnumerable)} 接口");
            }
            DataSource = data.Cast<object>().ToList();

            CurrentPage = page;
            IsCompleted = true;
            StateHasChanged();
        }

        /// <summary>
        /// 获取行的 css 字符串。
        /// </summary>
        /// <param name="index">行的索引。</param>
        private string GetRowCssByIndex(int index)
        {
            if (!RowCssList.ContainsKey(index))
            {
                return string.Empty;
            }
            return string.Join(" ", RowCssList[index]);
        }

        /// <summary>
        /// 获取行的 style 字符串。
        /// </summary>
        /// <param name="index">行的索引。</param>
        private string GetRowStyleByIndex(int index)
        {
            if (!RowStyleList.ContainsKey(index))
            {
                return string.Empty;
            }
            return string.Join(" ", RowStyleList[index]);
        }

        /// <summary>
        /// 获取自动列宽。
        /// </summary>
        /// <returns></returns>
       internal double GetAutoColumnWidth()
        {
            var avg = Columns.Where(m => string.IsNullOrEmpty(m.Width))
                .Average(m => 100 / Columns.Count);
            return Math.Round(avg, 1);
        }
    }
}
