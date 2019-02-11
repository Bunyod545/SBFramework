using System.Collections.Generic;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo PrimaryColumn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColumnInfo> Columns { get; set; }
    }
}
