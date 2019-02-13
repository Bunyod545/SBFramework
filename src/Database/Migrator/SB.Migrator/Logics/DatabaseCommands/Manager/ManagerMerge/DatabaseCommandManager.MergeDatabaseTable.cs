using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models;

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
                DropDatabaseTable(databaseTable);
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
