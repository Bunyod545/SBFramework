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
        MigrateManager MigrateManager { get; set; }

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
