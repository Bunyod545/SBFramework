using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate.Helpers;
using System.IO;

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
        public abstract ExcelPackage Generate();

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
    }
}
