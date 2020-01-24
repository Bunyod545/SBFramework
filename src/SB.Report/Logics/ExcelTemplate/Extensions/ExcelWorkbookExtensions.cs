using OfficeOpenXml;
using System.Linq;

namespace SB.Report.Logics.ExcelTemplate.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExcelWorkbookExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="tempWorkbook"></param>
        public static void InitializeFromTemplate(this ExcelWorkbook workbook, ExcelWorkbook tempWorkbook)
        {
            var tempWorksheets = tempWorkbook.Worksheets.ToList();
            tempWorksheets.ForEach(f => InitializeWorksheet(workbook, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ws"></param>
        private static void InitializeWorksheet(ExcelWorkbook workbook, ExcelWorksheet tempWorksheet)
        {
            var worksheet = workbook.Worksheets.Add(tempWorksheet.Name);
            InitializeWorksheetColumns(worksheet, tempWorksheet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ws"></param>
        private static void InitializeWorksheetColumns(ExcelWorksheet worksheet, ExcelWorksheet tempWorksheet)
        {
            var tempColumns = tempWorksheet.GetColumns().ToList();
            tempColumns.ForEach(f => worksheet.CopyColumnFromTemplate(f));
        }
    }
}
