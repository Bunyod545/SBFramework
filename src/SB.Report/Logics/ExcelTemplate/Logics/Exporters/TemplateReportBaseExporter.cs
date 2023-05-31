using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate.Extensions;
using SB.Report.Logics.ExcelTemplate.Logics.Exporters.Attributes;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportBaseExporter : ITemplateReportExporter
    {
        /// <summary>
        /// 
        /// </summary>
        public ExcelTemplateReport Report { get; }

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportExportCalculator ExportCalculator => Report.ExportCalculator;

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportExportValueReplacer ExportValueReplacer => Report.ExportValueReplacer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        public TemplateReportBaseExporter(ExcelTemplateReport report)
        {
            Report = report;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <returns></returns>
        protected ExcelNamedRange GetTempNamedRange(string tempNamedRangeName)
        {
            var tempNamedRange = Report.GetTempNamedRange(tempNamedRangeName);
            if (tempNamedRange == null)
                throw new Exception($"Template named range not found with name: {tempNamedRangeName}");

            return tempNamedRange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        protected Dictionary<string, object> GetPropertyValues<T>(T values) where T : class
        {
            var props = values.GetType().GetProperties().ToList();
            var dicValues = new Dictionary<string, object>();
            props.ForEach(f => dicValues.Add(GetPropertyName(f),f.GetValue(values)));

            return dicValues;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        protected string GetPropertyName(PropertyInfo property)
        {
            var attr = property.GetCustomAttribute<TemplateReportPropertyAttribute>();
            return attr?.Name ?? property.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        protected ExcelRange ExportRange(string address, ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            var worksheet = Report.GetWorksheet(tempNamedRange.Worksheet.Name);

            var cellRange = worksheet.Cells[address];
            tempNamedRange.Copy(cellRange);
            tempNamedRange.CopySettings(cellRange);

            ExportValueReplacer.Replace(cellRange, values);
            return cellRange;
        }
    }
}