﻿using System.Collections.Generic;
using SB.Migrator.Models;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        CommandServices CommandServices { get; }

        /// <summary>
        /// 
        /// </summary>
        IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IDatabaseCommand> Commands { get; }

        /// <summary>
        /// 
        /// </summary>
        void MergeTables(List<TableInfo> codeTables, List<TableInfo> databaseTables);

        /// <summary>
        /// 
        /// </summary>
        void Migrate();
    }
}