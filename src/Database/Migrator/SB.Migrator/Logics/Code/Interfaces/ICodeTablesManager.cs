﻿using System.Collections.Generic;
using SB.Migrator.Models.Table;

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
        /// <returns></returns>
        List<TableInfo> GetTableInfos();
    }
}