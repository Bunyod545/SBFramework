﻿using System.Collections.Generic;
using SB.Migrator.Models;
using SB.Migrator.Models.MigrationHistories;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.Logics.Code
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        void Initialize();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ScriptInfo> GetBeforeActualizationScripts();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ScriptInfo> GetAfterActualizationScripts();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TableInfo> GetTableInfos();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<MigrationVersionInfo> GetMigrationVersionInfos();
    }
}
