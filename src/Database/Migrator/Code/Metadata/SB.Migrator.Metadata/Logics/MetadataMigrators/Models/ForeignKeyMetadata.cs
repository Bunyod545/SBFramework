using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeignKeyMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnMetadata Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableMetadata Table { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ReferencedTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferencedColumn { get; set; }
    }
}
