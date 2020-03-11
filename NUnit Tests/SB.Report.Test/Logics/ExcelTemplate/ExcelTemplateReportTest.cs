using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using SB.Report.Test.Logics.ExcelTemplate.Reports.Models;

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
        public void Test()
        {
            var customReport = new CustomExcelTemplateReport();
            var info = new CustomExcelTemplateReportInfo();
            info.Header = new CustomExcelHeaderTemplate();
            info.Header.BeginDate = DateTime.Now.StartOfMonth().ToShortDateString();
            info.Header.EndDate = DateTime.Now.ToShortDateString();

            info.Rows = new List<CustomExcelRowTemplate>();
            var row = new CustomExcelRowTemplate();
            row.GroupName = "Test";
            info.Rows.Add(row);

            customReport.Export(info);

            customReport.SaveReport("Test.xlsx");
        }

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
