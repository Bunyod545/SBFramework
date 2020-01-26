using System.Collections.Generic;
using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITemplateReportExportValueReplacer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="values"></param>
        void Replace(ExcelRange range, Dictionary<string, object> values);
    }
}
