using System.Collections.Generic;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class TableValueMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public TableMetadata Table { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TableValueItemMetadata> ValueMetadata { get; set; }
    }
}
