﻿using System.Collections.Generic;
using System.Linq;
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
        public MigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<IDatabaseCommand> Commands { get; }

        /// <summary>
        /// 
        /// </summary>
        public DatabaseCommandManager(MigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
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
            Commands.Clear();
            codeTables.ForEach(f => MergeCodeTable(f, databaseTables));
            databaseTables.ForEach(f => MergeDatabaseTable(f, codeTables));
        }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            var commands = Commands.OrderBy(o => o.Order).ToList();
            commands.ForEach(f => f.Execute(MigrateManager.ConnectionString));
        }
    }
}
