using System.IO;
using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate.Helpers;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportFinder : ITemplateReportFinder
    {
        /// <summary>
        /// 
        /// </summary>
        public ExcelTemplateReport Report { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        public TemplateReportFinder(ExcelTemplateReport report)
        {
            Report = report;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ExcelPackage GetTemplate()
        {
            var templateReportStream = TemplateReportHelper.GetTemplateReportStream(Report);
            if (templateReportStream == null)
                throw new FileNotFoundException("Excel template report not found!");

            return new ExcelPackage(templateReportStream);
        }
    }
}
