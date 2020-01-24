using OfficeOpenXml;
using System.Collections.Generic;

namespace SB.Report.Logics.ExcelTemplate.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExcelWorksheetExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ExcelColumnInfo> GetColumns(this ExcelWorksheet worksheet)
        {
            var columnStart = worksheet.Dimension.Start.Column;
            var columnEnd = worksheet.Dimension.End.Column;

            for (int currentColumn = columnStart; currentColumn <= columnEnd; currentColumn++)
                yield return new ExcelColumnInfo(worksheet.Column(currentColumn), currentColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="tempColumn"></param>
        public static void CopyColumnFromTemplate(this ExcelWorksheet worksheet, ExcelColumnInfo tempColumn)
        {
            worksheet.InsertColumn(tempColumn.Index, 1);
            var column = worksheet.Column(tempColumn.Index);
            column.CopyFromTemplate(tempColumn.Column);
        } 
    }
}
