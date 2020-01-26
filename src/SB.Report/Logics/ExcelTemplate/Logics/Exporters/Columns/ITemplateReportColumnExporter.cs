using System.Collections.Generic;
using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITemplateReportColumnExporter : ITemplateReportExporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        void ExportColumn<T>(string tempNamedRangeName, T values) where T : class;
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        void ExportColumn<T>(ExcelNamedRange tempNamedRange, T values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        void ExportColumns<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        void ExportColumns<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        void ExportColumn(string tempNamedRangeName, Dictionary<string, object> values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        void ExportColumn(ExcelNamedRange tempNamedRange, Dictionary<string, object> values);
    }
}