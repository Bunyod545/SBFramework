using System;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnExportAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnExportAttribute()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ColumnExportAttribute(string name)
        {
            Name = name;
        }
    }
}
