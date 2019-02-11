using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SB.EntityFramework;
using SB.EntityFramework.Context;
using SB.Migrator.Logics.Code;
using SB.Migrator.Models;
using TypeInfo = SB.EntityFramework.TypeInfo;

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
            var types = GetContextTypes();
            return types.SelectMany(GetTable).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Type> GetContextTypes()
        {
            var types = TableFinder.GetContextTypes();
            return types.Select(GetMigrateContextType).Where(w => w != null).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        private Type GetMigrateContextType(Type contextType)
        {
            var attr = contextType?.GetCustomAttribute<SBMigrationAttribute>();
            if (attr == null)
                return null;

            return contextType.IsAbstract ? null : contextType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        private List<EFTableInfo> GetTable(Type contextType)
        {
            if (!(Activator.CreateInstance(contextType) is EFContext context))
                return new List<EFTableInfo>();

            var entityTypes = context.Model.GetEntityTypes();
            return entityTypes.Select(ConvertToTableInfo).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private EFTableInfo ConvertToTableInfo(IEntityType entity)
        {
            var mapping = entity.Relational();

            var tableInfo = new EFTableInfo();
            tableInfo.Name = mapping.TableName;
            tableInfo.Schema = mapping.Schema;

            return tableInfo;
        }
    }
}
