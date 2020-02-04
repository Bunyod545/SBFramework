using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using SB.Common.Extensions;

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
            var templateReportStream = GetTemplateReportStream(Report);
            if (templateReportStream == null)
                throw new FileNotFoundException("Excel template report not found!");

            return new ExcelPackage(templateReportStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public static Stream GetTemplateReportStream(ExcelTemplateReport report)
        {
            var name = GetTemplateReportName(report);
            if (name == null)
                return null;

            var ass = report.GetType().Assembly;
            var files = ass.GetManifestResourceNames().ToList();
            var tempReportFile = files.FirstOrDefault(f => f.EndsWith(name));
            if (tempReportFile == null)
                return null;

            return ass.GetManifestResourceStream(tempReportFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public static string GetTemplateReportName(ExcelTemplateReport report)
        {
            if (report == null)
                return string.Empty;

            var reportType = report.GetType();
            var tempAttr = reportType.GetCustomAttribute<ExcelTemplateAttribute>();
            if (tempAttr != null && !tempAttr.TemplateName.IsNullOrEmpty())
                return tempAttr.TemplateName;

            return reportType.Name + report.GetFileExtension();
        }
    }
}
