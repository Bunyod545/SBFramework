using System.Collections.Generic;
using SB.Migrator.Models;
using SB.Migrator.Models.Tables.Values;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public class TableValueInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TableValueItemInfo> Value { get; set; }
    }
}
