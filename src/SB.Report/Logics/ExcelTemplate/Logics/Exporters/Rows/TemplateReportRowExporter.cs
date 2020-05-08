using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportRowExporter : TemplateReportBaseExporter, ITemplateReportRowExporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        public TemplateReportRowExporter(ExcelTemplateReport report) : base(report)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        public ExcelRange ExportRow(string tempNamedRangeName)
        {
            return ExportRow(tempNamedRangeName, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        public ExcelRange ExportRow(ExcelNamedRange tempNamedRange)
        {
            return ExportRow(tempNamedRange, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public ExcelRange ExportRow<T>(string tempNamedRangeName, T values) where T : class
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            return ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public ExcelRange ExportRow<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            var dicValues = GetPropertyValues(values);
            return ExportRow(tempNamedRange, dicValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public List<ExcelRange> ExportRows(string tempNamedRangeName, IEnumerable values)
        {
            var result = new List<ExcelRange>();
            var enumerator = values.GetEnumerator();
            while (enumerator.MoveNext())
                result.Add(ExportRow(tempNamedRangeName, enumerator.Current));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public List<ExcelRange> ExportRows<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            return valueList.Select(f => ExportRow(tempNamedRangeName, f)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public List<ExcelRange> ExportRows<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            return valueList.Select(f => ExportRow(tempNamedRange, f)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public ExcelRange ExportRow(string tempNamedRangeName, Dictionary<string, object> values)
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            return ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public ExcelRange ExportRow(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            var address = ExportCalculator.GetExportRowAddress(tempNamedRange);
            return ExportRange(address, tempNamedRange, values);
        }
    }
}