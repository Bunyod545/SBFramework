using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate.Extensions;
using SB.Report.Logics.ExcelTemplate.Helpers;
using System.IO;
using System.Linq;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ExcelTemplateReport
    {
        /// <summary>
        /// 
        /// </summary>
        public int CurrentRowIndex { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public int CurrentColumnIndex { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public ExcelPackage ExcelTempReport { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ExcelPackage ExcelReport { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ExcelTemplateReport()
        {
            InitializeExcelReport();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void InitializeExcelReport()
        {
            ExcelTempReport = GetTemplate();
            ExcelReport = new ExcelPackage();
            ExcelReport.Workbook.InitializeFromTemplate(ExcelTempReport.Workbook);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ExcelPackage GetTemplate()
        {
            var templateReportStream = TemplateReportHelper.GetTemplateReportStream(this);
            if (templateReportStream == null)
                throw new FileNotFoundException("Excel template report not found!");

            return new ExcelPackage(templateReportStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual ExcelWorksheet GetTempWorksheet(string name)
        {
            return ExcelTempReport.Workbook.Worksheets.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual ExcelWorksheet GetTempWorksheet(int index)
        {
            return ExcelTempReport.Workbook.Worksheets.FirstOrDefault(f => f.Index == index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual ExcelWorksheet GetWorksheet(string name)
        {
            return ExcelReport.Workbook.Worksheets.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual ExcelWorksheet GetWorksheet(int index)
        {
            return ExcelReport.Workbook.Worksheets.FirstOrDefault(f => f.Index == index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual ExcelNamedRange GetTempNamedRange(string name)
        {
            return ExcelTempReport.Workbook.Names.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="namedRange"></param>
        public virtual void ImportRow(ExcelNamedRange namedRange)
        {
            var worksheet = GetWorksheet(namedRange.Worksheet.Name);
            worksheet.InsertRow(CurrentRowIndex, namedRange.Rows);

            var startRow = CurrentRowIndex;
            var startColumn = namedRange.Start.Column;
            var endRow = startRow + namedRange.Rows - 1;
            var endColumn = namedRange.Columns;

            var cellRange = worksheet.Cells[startRow, startColumn, endRow, endColumn];
            namedRange.Copy(cellRange);

            CurrentRowIndex += namedRange.Rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="namedRange"></param>
        public virtual void ImportColumn(ExcelNamedRange namedRange)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void SaveReport()
        {
            var file = new FileInfo("Test.xlsx");
            ExcelReport.SaveAs(file);
        }
    }
}
