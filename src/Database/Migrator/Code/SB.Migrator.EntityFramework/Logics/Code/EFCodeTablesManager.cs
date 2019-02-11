using System;
using System.Collections.Generic;
using System.Linq;
using SB.EntityFramework;
using SB.Migrator.Logics.Code;
using SB.Migrator.Models;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFCodeTablesManager : ICodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<EFTableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetTableInfos()
        {
            _tableInfos = GetTables();

            return _tableInfos.Select(s => (TableInfo)s).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<EFTableInfo> GetTables()
        {
            var types = TableFinder.InitalizeTypeInfos();
            return types.Select(GetTable).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        private EFTableInfo GetTable(TypeInfo typeInfo)
        {
            var tableInfo = new EFTableInfo();
            tableInfo.Schema = typeInfo.Schema;
            tableInfo.Name = typeInfo.Schema;
            tableInfo.ClrType = typeInfo.ClrType;

            return tableInfo;
        }
    }
}
