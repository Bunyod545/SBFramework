using System.Collections;
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
        /// <param name="tempNamedRangeName"></param>
        ExcelRange ExportColumn(string tempNamedRangeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        ExcelRange ExportColumn(ExcelNamedRange tempNamedRange);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        ExcelRange ExportColumn<T>(string tempNamedRangeName, T values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        ExcelRange ExportColumn<T>(ExcelNamedRange tempNamedRange, T values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        List<ExcelRange> ExportColumns(string tempNamedRangeName, IEnumerable values);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        List<ExcelRange> ExportColumns<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        List<ExcelRange> ExportColumns<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        ExcelRange ExportColumn(string tempNamedRangeName, Dictionary<string, object> values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        ExcelRange ExportColumn(ExcelNamedRange tempNamedRange, Dictionary<string, object> values);

        /// <summary>
        /// 
        /// </summary>
        void ExportColumnsFinished();
    }
}