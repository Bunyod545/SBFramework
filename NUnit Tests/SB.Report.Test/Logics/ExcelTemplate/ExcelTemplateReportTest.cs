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
            var headerRange = customReport.GetTempNamedRange("header");
            customReport.ImportColumn(headerRange);
            customReport.ImportColumn(headerRange);

            var rowRange = customReport.GetTempNamedRange("row");
            for (int i = 0; i < 50; i++)
                customReport.ImportRow(rowRange);

            customReport.SaveReport();
            Assert.NotNull(customReport.ExcelTempReport);
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
