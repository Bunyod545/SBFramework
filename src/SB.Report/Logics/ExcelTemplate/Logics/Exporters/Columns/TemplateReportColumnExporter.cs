using System;
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
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportColumn<T>(string tempNamedRangeName, T values) where T : class
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public void ExportColumn<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            if (Equals(values, null))
                return;

            var dicValues = GetPropertyValues(values);
            ExportColumn(tempNamedRange, dicValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportColumns<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            valueList.ForEach(f => ExportColumn(tempNamedRangeName, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public void ExportColumns<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            var valueList = values.ToList();
            valueList.ForEach(f => ExportColumn(tempNamedRange, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public void ExportColumn(string tempNamedRangeName, Dictionary<string, object> values)
        {
            var tempNamedRange = GetTempNamedRange(tempNamedRangeName);
            ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public void ExportColumn(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            var worksheet = Report.GetWorksheet(tempNamedRange.Worksheet.Name);
            var address = ExportCalculator.GetExportRowAddress(tempNamedRange);

            var cellRange = worksheet.Cells[address];
            tempNamedRange.Copy(cellRange);
            ExportValueReplacer.Replace(cellRange, values);
        }
    }
}