﻿using System.Collections.Generic;
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
        /// <returns></returns>
        List<TableInfo> GetTableInfos();
    }
}
