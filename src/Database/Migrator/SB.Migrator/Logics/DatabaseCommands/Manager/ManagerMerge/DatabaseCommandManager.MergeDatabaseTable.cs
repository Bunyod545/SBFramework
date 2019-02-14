using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

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
        /// <param name="databaseTable"></param>
        protected virtual void DropDatabaseTable(TableInfo databaseTable)
        {
            DropTable(databaseTable);
            databaseTable.ForeignKeys.ForEach(DropForeignKey);
        }
    }
}
