using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate;

namespace SB.Report.Test.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    [ExcelTemplate("CustomExcelTemplateReport.xlsx")]
    public class CustomExcelTemplateReport : ExcelTemplateReport
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ExcelPackage Generate()
        {
            return new ExcelPackage();
        }
    }
}
