﻿using System.Collections;
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
        public virtual ExcelRange ExportRow(string tempNamedRangeName)
        {
            return RowExporter.ExportRow(tempNamedRangeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        public virtual ExcelRange ExportRow(ExcelNamedRange tempNamedRange)
        {
            return RowExporter.ExportRow(tempNamedRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportRow<T>(string tempNamedRangeName, T values) where T : class
        {
            return RowExporter.ExportRow(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportRow<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
            return RowExporter.ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual List<ExcelRange> ExportRows(string tempNamedRangeName, IEnumerable values)
        {
           return RowExporter.ExportRows(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual List<ExcelRange> ExportRows<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
           return RowExporter.ExportRows(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual List<ExcelRange> ExportRows<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
           return RowExporter.ExportRows(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportRow(string tempNamedRangeName, Dictionary<string, object> values)
        {
            return RowExporter.ExportRow(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportRow(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
           return RowExporter.ExportRow(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        public virtual ExcelRange ExportColumn(string tempNamedRangeName)
        {
           return ColumnExporter.ExportColumn(tempNamedRangeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        public virtual ExcelRange ExportColumn(ExcelNamedRange tempNamedRange)
        {
            return ColumnExporter.ExportColumn(tempNamedRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportColumn<T>(string tempNamedRangeName, T values) where T : class
        {
           return ColumnExporter.ExportColumn(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportColumn<T>(ExcelNamedRange tempNamedRange, T values) where T : class
        {
           return ColumnExporter.ExportColumn(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual List<ExcelRange> ExportColumns(string tempNamedRangeName, IEnumerable values)
        {
           return ColumnExporter.ExportColumns(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual List<ExcelRange> ExportColumns<T>(string tempNamedRangeName, IEnumerable<T> values) where T : class
        {
           return ColumnExporter.ExportColumns(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual List<ExcelRange> ExportColumns<T>(ExcelNamedRange tempNamedRange, IEnumerable<T> values) where T : class
        {
            return ColumnExporter.ExportColumns(tempNamedRange, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRangeName"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportColumn(string tempNamedRangeName, Dictionary<string, object> values)
        {
            return ColumnExporter.ExportColumn(tempNamedRangeName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempNamedRange"></param>
        /// <param name="values"></param>
        public virtual ExcelRange ExportColumn(ExcelNamedRange tempNamedRange, Dictionary<string, object> values)
        {
            return ColumnExporter.ExportColumn(tempNamedRange, values);
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
