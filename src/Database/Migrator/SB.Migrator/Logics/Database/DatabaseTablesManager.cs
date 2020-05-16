using System.Collections.Generic;
using SB.Migrator.Models;

namespace SB.Migrator.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DatabaseTablesManager : IDatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string DefaultSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<TableInfo> GetTableInfos();
    }
}
