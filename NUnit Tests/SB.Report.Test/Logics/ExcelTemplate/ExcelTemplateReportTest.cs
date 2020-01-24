using NUnit.Framework;
using System.IO;

namespace SB.Report.Test.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcelTemplateReportTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetTemplateTest()
        {
            var customReport = new CustomExcelTemplateReport();
            var tempReport = customReport.GetTemplate();

            var sheet = tempReport.Workbook.Worksheets[0];
            var name = sheet.Names["Test"];

            Assert.NotNull(tempReport);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetTemplateTestWithOutTempFile()
        {
            var withoutTempReport = new WithoutExcelTemplateReport();
            Assert.Throws<FileNotFoundException>(() => withoutTempReport.GetTemplate());
        }
    }
}
