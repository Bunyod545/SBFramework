using System;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class RowExportAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RowExportAttribute()
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public RowExportAttribute(string name)
        {
            Name = name;
        }
    }
}
