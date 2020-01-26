using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportExportCalculator : ITemplateReportExportCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        public int ImportedColumnRowsCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RowIndex { get; protected set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public int ColumnIndex { get; protected set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        public string GetExportRowAddress(ExcelNamedRange tempNamedRange)
        {
            if (ImportedColumnRowsCount > 0)
                RowIndex += ImportedColumnRowsCount;

            ImportedColumnRowsCount = 0;

            var startRow = RowIndex;
            var startColumn = tempNamedRange.Start.Column;
            var endRow = startRow + tempNamedRange.Rows - 1;
            var endColumn = tempNamedRange.Columns;
            var address = ExcelCellBase.GetAddress(startRow, startColumn, endRow, endColumn);

            RowIndex += tempNamedRange.Rows;
            ColumnIndex = tempNamedRange.Columns;
            return address;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <returns></returns>
        public string GetExportColumnAddress(ExcelNamedRange tempNamedRange)
        {
            var startRow = RowIndex;
            var startColumn = ColumnIndex + tempNamedRange.Start.Column - 1;
            var endRow = startRow + tempNamedRange.Rows - 1;
            var endColumn = ColumnIndex + tempNamedRange.Columns - 1;
            var address = ExcelCellBase.GetAddress(startRow, startColumn, endRow, endColumn);

            ColumnIndex += tempNamedRange.Columns;
            if (ImportedColumnRowsCount == 0 || ImportedColumnRowsCount < tempNamedRange.Rows)
                ImportedColumnRowsCount = tempNamedRange.Rows;

            return address;
        }
    }
}