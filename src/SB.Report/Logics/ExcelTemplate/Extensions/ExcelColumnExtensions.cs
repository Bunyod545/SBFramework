using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExcelColumnExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="tempColumn"></param>
        public static void CopyFromTemplate(this ExcelColumn column, ExcelColumn tempColumn)
        {
            column.Width = tempColumn.Width;
        }
    }
}
