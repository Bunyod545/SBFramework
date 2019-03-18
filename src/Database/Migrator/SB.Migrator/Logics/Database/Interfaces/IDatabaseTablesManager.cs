using System.Collections.Generic;
using SB.Migrator.Models;

namespace SB.Migrator.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        IColumnTypeMappingSource ColumnTypeMappingSource { get; }

        /// <summary>
        /// 
        /// </summary>
        string DefaultSchema { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TableInfo> GetTableInfos();
    }
}
