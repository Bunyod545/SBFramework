using System.Collections.Generic;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;

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
        MigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TableInfo> GetTableInfos();
    }
}
