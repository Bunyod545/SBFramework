using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTable"></param>
        /// <param name="codeTables"></param>
        protected virtual void MergeDatabaseTable(TableInfo databaseTable, List<TableInfo> codeTables)
        {
            var codeTable = codeTables.FirstOrDefault(f => f.IsEqual(databaseTable));
            if (codeTable == null)
            {
                DropDatabaseTable(databaseTable);
                return;
            }

            databaseTable.Columns.ForEach(f => MergeDatabaseColumn(f, codeTable));
            databaseTable.ForeignKeys.ForEach(f => MergeDatabaseTableForeignKey(f, codeTable.ForeignKeys));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseColumn"></param>
        /// <param name="codeTable"></param>
        protected virtual void MergeDatabaseColumn(ColumnInfo databaseColumn, TableInfo codeTable)
        {
            var codeColumn = codeTable.GetColumn(databaseColumn.Name);
            if (codeColumn == null)
                DropColumn(databaseColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseForeignKey"></param>
        /// <param name="codeForeignKeys"></param>
        protected virtual void MergeDatabaseTableForeignKey(ForeignKeyInfo databaseForeignKey, List<ForeignKeyInfo> codeForeignKeys)
        {
            var codeForeignKey = codeForeignKeys.FirstOrDefault(f => f.IsEqual(databaseForeignKey));
            if (codeForeignKey == null)
                DropForeignKey(databaseForeignKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTable"></param>
        protected virtual void DropDatabaseTable(TableInfo databaseTable)
        {
            DropTable(databaseTable);
            databaseTable.ForeignKeys.ForEach(DropForeignKey);
        }
    }
}
