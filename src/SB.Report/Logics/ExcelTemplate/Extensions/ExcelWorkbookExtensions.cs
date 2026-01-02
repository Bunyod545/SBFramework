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
        /// <param name="workbook"></param>
        /// <param name="tempWorksheet"></param>
        private static void InitializeWorksheet(ExcelWorkbook workbook, ExcelWorksheet tempWorksheet)
        {
            var worksheet = workbook.Worksheets.Add(tempWorksheet.Name);
            InitializeWorksheetPrinterSettings(worksheet, tempWorksheet);
            InitializeWorksheetColumns(worksheet, tempWorksheet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="tempWorksheet"></param>
        private static void InitializeWorksheetPrinterSettings(ExcelWorksheet worksheet, ExcelWorksheet tempWorksheet)
        {
            worksheet.PrinterSettings.BlackAndWhite = tempWorksheet.PrinterSettings.BlackAndWhite;
            worksheet.PrinterSettings.LeftMargin = tempWorksheet.PrinterSettings.LeftMargin;
            worksheet.PrinterSettings.RightMargin = tempWorksheet.PrinterSettings.RightMargin;
            worksheet.PrinterSettings.TopMargin = tempWorksheet.PrinterSettings.TopMargin;
            worksheet.PrinterSettings.BottomMargin = tempWorksheet.PrinterSettings.BottomMargin;
            worksheet.PrinterSettings.HeaderMargin = tempWorksheet.PrinterSettings.HeaderMargin;
            worksheet.PrinterSettings.FooterMargin = tempWorksheet.PrinterSettings.FooterMargin;
            worksheet.PrinterSettings.Orientation = tempWorksheet.PrinterSettings.Orientation;
            worksheet.PrinterSettings.FitToWidth = tempWorksheet.PrinterSettings.FitToWidth;
            worksheet.PrinterSettings.FitToHeight = tempWorksheet.PrinterSettings.FitToHeight;
            worksheet.PrinterSettings.Scale = tempWorksheet.PrinterSettings.Scale;
            worksheet.PrinterSettings.FitToPage = tempWorksheet.PrinterSettings.FitToPage;
            worksheet.PrinterSettings.ShowHeaders = tempWorksheet.PrinterSettings.ShowHeaders;
            worksheet.PrinterSettings.PrintArea = tempWorksheet.PrinterSettings.PrintArea;
            worksheet.PrinterSettings.ShowGridLines = tempWorksheet.PrinterSettings.ShowGridLines;
            worksheet.PrinterSettings.HorizontalCentered = tempWorksheet.PrinterSettings.HorizontalCentered;
            worksheet.PrinterSettings.VerticalCentered = tempWorksheet.PrinterSettings.VerticalCentered;
            worksheet.PrinterSettings.PageOrder = tempWorksheet.PrinterSettings.PageOrder;
            worksheet.PrinterSettings.BlackAndWhite = tempWorksheet.PrinterSettings.BlackAndWhite;
            worksheet.PrinterSettings.Draft = tempWorksheet.PrinterSettings.Draft;
            worksheet.PrinterSettings.PaperSize = tempWorksheet.PrinterSettings.PaperSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="tempWorksheet"></param>
        private static void InitializeWorksheetColumns(ExcelWorksheet worksheet, ExcelWorksheet tempWorksheet)
        {
            var tempColumns = tempWorksheet.GetColumns().ToList();
            tempColumns.ForEach(worksheet.CopyColumnFromTemplate);
        }
    }
}
