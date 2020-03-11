using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;
using SB.Report.Logics.ExcelTemplate.Logics.ObjectExporters;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ExcelTemplateReport
    {
        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportExportCalculator ExportCalculator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportExportValueReplacer ExportValueReplacer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportObjectExporter ObjectExporter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportRowExporter RowExporter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportColumnExporter ColumnExporter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeExports()
        {
            InternalInitializeExports();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InternalInitializeExports()
        {
            ExportCalculator = new TemplateReportExportCalculator();
            ExportValueReplacer = new TemplateReportExportValueReplacer();
            ObjectExporter = new TemplateReportObjectExporter(this);
            RowExporter = new TemplateReportRowExporter(this);
            ColumnExporter = new TemplateReportColumnExporter(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportInfo"></param>
        public virtual void Export<T>(T reportInfo) where T : class
        {
            ObjectExporter.Export(reportInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        public virtual void ExportRow(string tempNamedRangeName)
        {
            RowExporter.ExportRow(tempNamedRangeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        public virtual void ExportRow(ExcelNamedRange tempNamedRange)
        {
            RowExporter.ExportRow(tempNamedRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportRow<T>(string tempNamedRangeName, T values) where T : class
        {
            RowExporter.ExportRow(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual void ExportRow<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            RowExporter.ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportRows(string tempNamedRangeName, IEnumerable values)
        {
            RowExporter.ExportRows(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportRows<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
            RowExporter.ExportRows(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual void ExportRows<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            RowExporter.ExportRows(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportRow(string tempNamedRangeName, Dictionary<string, object> values)
        {
            RowExporter.ExportRow(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual void ExportRow(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            RowExporter.ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        public virtual void ExportColumn(string tempNamedRangeName)
        {
            ColumnExporter.ExportColumn(tempNamedRangeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        public virtual void ExportColumn(ExcelNamedRange tempNamedRange)
        {
            ColumnExporter.ExportColumn(tempNamedRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportColumn<T>(string tempNamedRangeName, T values) where T : class
        {
            ColumnExporter.ExportColumn(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual void ExportColumn<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            ColumnExporter.ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportColumns(string tempNamedRangeName, IEnumerable values)
        {
            ColumnExporter.ExportColumn(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportColumns<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
            ColumnExporter.ExportColumn(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual void ExportColumns<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            ColumnExporter.ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual void ExportColumn(string tempNamedRangeName, Dictionary<string, object> values)
        {
            ColumnExporter.ExportColumn(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual void ExportColumn(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            ColumnExporter.ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ExportColumnsFinished()
        {
            ColumnExporter.ExportColumnsFinished();
        }
    }
}
