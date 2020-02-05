using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExcelRowExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tempRow"></param>
        public static void CopyFromTemplate(this ExcelRow row, ExcelRow tempRow)
        {
            row.Height = tempRow.Height;
        }
    }
}
