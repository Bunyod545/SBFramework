using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportColumnExporter : TemplateReportBaseExporter, ITemplateReportColumnExporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        public TemplateReportColumnExporter(ExcelTemplateReport report) : base(report)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        public ExcelRange ExportColumn(string tempNamedRangeName)
        {
            return ExportColumn(tempNamedRangeName, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        public ExcelRange ExportColumn(ExcelNamedRange tempNamedRange)
        {
            return ExportColumn(tempNamedRange, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public ExcelRange ExportColumn<T>(string tempNamedRangeName, T values) where T : class
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            return ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public ExcelRange ExportColumn<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            var dicValues = GetPropertyValues(values);
            return ExportColumn(tempNamedRange, dicValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public List<ExcelRange> ExportColumns(string tempNamedRangeName, IEnumerable values)
        {
            var result = new List<ExcelRange>();
            var enumerator = values.GetEnumerator();
            while (enumerator.MoveNext())
               result.Add(ExportColumn(tempNamedRangeName, enumerator.Current));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public List<ExcelRange> ExportColumns<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            return valueList.Select(f => ExportColumn(tempNamedRangeName, f)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public List<ExcelRange> ExportColumns<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            return valueList.Select(f => ExportColumn(tempNamedRange, f)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public ExcelRange ExportColumn(string tempNamedRangeName, Dictionary<string, object> values)
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            return ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public ExcelRange ExportColumn(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            var address = ExportCalculator.GetExportColumnAddress(tempNamedRange);
            return ExportRange(address, tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExportColumnsFinished()
        {
            ExportCalculator.ExportColumnsFinished();
        }
    }
}