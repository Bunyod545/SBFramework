using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExcelNamedRangeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="namedRange"></param>
        /// <param name="range"></param>
        public static void CopySettings(this ExcelNamedRange namedRange, ExcelRange range)
        {
            namedRange.CopyColumnsSettings(range);
            namedRange.CopyRowsSettings(range);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="namedRange"></param>
        /// <param name="range"></param>
        private static void CopyColumnsSettings(this ExcelNamedRange namedRange, ExcelRange range)
        {
            for (var i = 0; i < namedRange.Columns; i++)
            {
                var tempColumnIndex = namedRange.Start.Column + i;
                var tempColumn = namedRange.Worksheet.Column(tempColumnIndex);

                var columnIndex = range.Start.Column + i;
                var column = range.Worksheet.Column(columnIndex);
                column.CopyFromTemplate(tempColumn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namedRange"></param>
        /// <param name="range"></param>
        private static void CopyRowsSettings(this ExcelNamedRange namedRange, ExcelRange range)
        {
            for (var i = 0; i < namedRange.Rows; i++)
            {
                var tempRowIndex = namedRange.Start.Row + i;
                var tempRow = namedRange.Worksheet.Row(tempRowIndex);

                var rowIndex = range.Start.Column + i;
                var row = range.Worksheet.Row(rowIndex);
                row.CopyFromTemplate(tempRow);
            }
        }
    }
}
