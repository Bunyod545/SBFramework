using System;
using System.Collections.Generic;
using SB.Migrator.Models;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseCommandManager : IDatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandServices CommandServices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IDatabaseCommand> Commands { get; }

        /// <summary>
        /// 
        /// </summary>
        public DatabaseCommandManager()
        {
            CommandServices = new CommandServices();
            Commands = new List<IDatabaseCommand>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeTables"></param>
        /// <param name="databaseTables"></param>
        public void MergeTables(List<TableInfo> codeTables, List<TableInfo> databaseTables)
        {
            codeTables.ForEach(f => MergeCodeTable(f, databaseTables));
            databaseTables.ForEach(f => MergeDatabaseTable(f, codeTables));
        }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            throw new NotImplementedException();
        }
    }
}
