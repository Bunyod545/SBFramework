using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITemplateReportRowExporter : ITemplateReportExporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        ExcelRange ExportRow(string tempNamedRangeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        ExcelRange ExportRow(ExcelNamedRange tempNamedRange);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        ExcelRange ExportRow<T>(string tempNamedRangeName, T values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        ExcelRange ExportRow<T>(ExcelNamedRange tempNamedRange, T values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        List<ExcelRange> ExportRows(string tempNamedRangeName, IEnumerable values);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        List<ExcelRange> ExportRows<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        List<ExcelRange> ExportRows<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        ExcelRange ExportRow(string tempNamedRangeName, Dictionary<string, object> values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        ExcelRange ExportRow(ExcelNamedRange tempNamedRange, Dictionary<string, object> values);
    }
}