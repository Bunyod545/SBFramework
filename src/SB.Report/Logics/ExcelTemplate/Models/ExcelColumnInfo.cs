using OfficeOpenXml;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcelColumnInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ExcelColumn Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExcelColumnInfo()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="index"></param>
        public ExcelColumnInfo(ExcelColumn column, int index)
        {
            Column = column;
            Index = index;
        }
    }
}