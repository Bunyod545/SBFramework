using System.Collections.Generic;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Models.Tables.Keys
{
    /// <summary>
    /// 
    /// </summary>
    public class UniqueKeyInfo : KeyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ColumnInfo> UniqueColumns { get; set; }
    }
}
