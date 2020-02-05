using System.Collections;
using System.Linq;
using System.Reflection;

namespace SB.Report.Logics.ExcelTemplate.Logics.ObjectExporters
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportObjectExporter : TemplateReportBaseExporter, ITemplateReportObjectExporter
    {
        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportColumnExporter ColumnExporter => Report.ColumnExporter;

        /// <summary>
        /// 
        /// </summary>
        public ITemplateReportRowExporter RowExporter => Report.RowExporter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        public TemplateReportObjectExporter(ExcelTemplateReport report) : base(report)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportInfo"></param>
        public void Export<T>(T reportInfo) where T : class
        {
            if (reportInfo == null)
                return;

            var properties = typeof(T).GetProperties().ToList();
            properties.ForEach(f => ExportByProperty(reportInfo, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportInfo"></param>
        /// <param name="prop"></param>
        private void ExportByProperty<T>(T reportInfo, PropertyInfo prop) where T : class
        {
            var columnExportAttr = prop.GetCustomAttribute<ColumnExportAttribute>();
            if (columnExportAttr != null)
            {
                ExportColumnByProperty(reportInfo, prop);
                return;
            }

            ExportRowByProperty(reportInfo, prop);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportInfo"></param>
        /// <param name="prop"></param>
        private void ExportColumnByProperty<T>(T reportInfo, PropertyInfo prop) where T : class
        {
            var columnExportAttr = prop.GetCustomAttribute<ColumnExportAttribute>();
            var rangeName = columnExportAttr.Name ?? prop.Name;

            var value = prop.GetValue(reportInfo);
            if (value == null)
                return;

            if (value is IEnumerable columnsValues)
            {
                ColumnExporter.ExportColumns(rangeName, columnsValues);
                return;
            }

            ColumnExporter.ExportColumn(rangeName, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportInfo"></param>
        /// <param name="prop"></param>
        private void ExportRowByProperty<T>(T reportInfo, PropertyInfo prop) where T : class
        {
            var rowExportAttr = prop.GetCustomAttribute<ColumnExportAttribute>();
            var rangeName = rowExportAttr?.Name ?? prop.Name;

            var value = prop.GetValue(reportInfo);
            if (value == null)
                return;

            if (value is IEnumerable rowsValues)
            {
                RowExporter.ExportRows(rangeName, rowsValues);
                return;
            }

            RowExporter.ExportRow(rangeName, value);
        }
    }
}