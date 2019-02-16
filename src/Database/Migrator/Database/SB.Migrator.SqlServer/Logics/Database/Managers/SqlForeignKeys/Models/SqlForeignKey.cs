using SB.Migrator.Models;
using SB.Migrator.Models.Column;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlForeignKey
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConstraintName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferencedTableSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferencedTableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferencedColumnName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DeleteAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UpdateAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public bool IsReferenceTable(TableInfo tableInfo)
        {
            return tableInfo.Schema == ReferencedTableSchema &&
                   tableInfo.Name == ReferencedTableName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnInfo"></param>
        /// <returns></returns>
        public bool IsReferenceColumn(ColumnInfo columnInfo)
        {
            return IsReferenceTable(columnInfo.Table) &&
                   columnInfo.Name == ReferencedColumnName;
        }
    }
}
