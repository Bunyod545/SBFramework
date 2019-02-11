using SB.Migrator.Models.Column;

namespace SB.Migrator.Models.Tables.Constraints
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeignKeyInfo : KeyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo ReferenceTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo ReferenceColumn { get; set; }
    }
}
