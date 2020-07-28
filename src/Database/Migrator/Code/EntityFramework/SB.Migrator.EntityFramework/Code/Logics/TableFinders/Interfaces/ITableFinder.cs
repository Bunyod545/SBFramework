using System.Collections.Generic;
using SB.Migrator.Models;
using SB.Migrator.Models.MigrationHistories;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITableFinder
    {
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