using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITemplateReportExportCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        int RowIndex { get; }

        /// <summary>
        /// 
        /// </summary>
        int ColumnIndex { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        string GetExportRowAddress(ExcelNamedRange tempNamedRange);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        string GetExportColumnAddress(ExcelNamedRange tempNamedRange);
    }
}