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
        public void ExportRow(string tempNamedRangeName)
        {
            ExportRow(tempNamedRangeName, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        public void ExportRow(ExcelNamedRange tempNamedRange) 
        {
            ExportRow(tempNamedRange, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportRow<T>(string tempNamedRangeName, T values) where T: class
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public void ExportRow<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            if (Equals(values, null))
                return;

            var dicValues = GetPropertyValues(values);
            ExportRow(tempNamedRange, dicValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportRows(string tempNamedRangeName, IEnumerable values)
        {
            var enumerator = values.GetEnumerator();
            while (enumerator.MoveNext())
                ExportRow(tempNamedRangeName, enumerator.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportRows<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            valueList.ForEach(f => ExportRow(tempNamedRangeName, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public void ExportRows<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            valueList.ForEach(f => ExportRow(tempNamedRange, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportRow(string tempNamedRangeName, Dictionary<string, object> values)
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public void ExportRow(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            var address = ExportCalculator.GetExportRowAddress(tempNamedRange);
            ExportRange(address, tempNamedRange, values);
        }
    }
}