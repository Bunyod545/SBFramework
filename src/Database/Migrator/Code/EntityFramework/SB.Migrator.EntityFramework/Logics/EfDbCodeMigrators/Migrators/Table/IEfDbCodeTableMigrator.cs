using System.Collections.Generic;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEfDbCodeTableMigrator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        EfDbCodeTableBuilder CreateTable(string tableName, string schemaName = null);

        /// <summary>
        /// 
        /// </summary>
        void DropTable(string table, string schema = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldTableName"></param>
        /// <param name="newTableName"></param>
        /// <param name="schema"></param>
        void RenameTable(string oldTableName, string newTableName, string schema = null);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<IDatabaseCommand> GetCommands();
    }
}
