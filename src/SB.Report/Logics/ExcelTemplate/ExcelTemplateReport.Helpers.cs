using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate.Extensions;
using System.Linq;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ExcelTemplateReport
    {
        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportFinder TemplateReportFinder { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected virtual void InternalInitializeExcelReport()
        {
            TemplateReportFinder = new TemplateReportFinder(this);
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
            return TemplateReportFinder.GetTemplate();
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
        /// <param name="index"></param>
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
        /// <param name="index"></param>
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
    }
}
