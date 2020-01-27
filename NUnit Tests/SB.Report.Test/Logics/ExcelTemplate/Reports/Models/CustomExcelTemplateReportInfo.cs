using System.Collections.Generic;

namespace SB.Report.Test.Logics.ExcelTemplate.Reports.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExcelTemplateReportInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomExcelHeaderTemplate Header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<CustomExcelRowTemplate> Rows { get; set; }
    }
}
