using OfficeOpenXml;
using System.IO;

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
        public ExcelPackage ExcelTempReport { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ExcelPackage ExcelReport { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected ExcelTemplateReport()
        {
            InitializeExcelReport();
            InitializeExports();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeExcelReport()
        {
            InternalInitializeExcelReport();
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Generate();

        /// <summary>
        /// 
        /// </summary>
        public virtual void SaveReport(string filePath)
        {
            var file = new FileInfo(filePath);
            ExcelReport.SaveAs(file);
        }
    }
}
