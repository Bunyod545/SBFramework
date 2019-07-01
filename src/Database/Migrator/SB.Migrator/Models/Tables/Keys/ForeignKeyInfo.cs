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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEqual(ForeignKeyInfo foreignKey)
        {
            if (foreignKey == null)
                return false;

            return Table.IsEqual(foreignKey.Table) &&
                   Column.IsEqual(foreignKey.Column) &&
                   ReferenceTable.IsEqual(foreignKey.ReferenceTable) &&
                   ReferenceColumn.IsEqual(foreignKey.ReferenceColumn);
        }
    }
}
