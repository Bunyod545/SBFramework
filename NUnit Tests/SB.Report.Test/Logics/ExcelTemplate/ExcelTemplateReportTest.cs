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
            Assert.NotNull(customReport.ExcelTempReport);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetTemplateTestWithOutTempFile()
        {
            Assert.Throws<FileNotFoundException>(() => new WithoutExcelTemplateReport());
        }
    }
}
