using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITemplateReportFinder
    {
        /// <summary>
        /// 
        /// </summary>
        ExcelTemplateReport Report { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ExcelPackage GetTemplate();
    }
}
