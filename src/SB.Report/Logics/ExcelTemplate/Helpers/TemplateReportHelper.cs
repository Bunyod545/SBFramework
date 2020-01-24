using System.IO;
using System.Linq;
using System.Reflection;

namespace SB.Report.Logics.ExcelTemplate.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TemplateReportHelper
    {
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

            var tempAttr = report.GetType().GetCustomAttribute<ExcelTemplateAttribute>();
            return tempAttr?.TemplateName;
        }
    }
}
