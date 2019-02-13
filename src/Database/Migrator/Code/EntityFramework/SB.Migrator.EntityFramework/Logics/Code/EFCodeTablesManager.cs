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
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;

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
        public IEFColumnTypeInfoCreator TypeInfoCreator { get; set; }

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

            var entityTypes = context.Model.GetEntityTypes().Where(w => !w.IsQueryType);
            return entityTypes.Select(s => ConvertToTableInfo(context, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private EFTableInfo ConvertToTableInfo(EFContext context, IEntityType entity)
        {
            if (entity.IsQueryType)
                return null;

            var mapping = entity.Relational();

            var tableInfo = new EFTableInfo();
            tableInfo.Context = context;
            tableInfo.Entity = entity;
            tableInfo.Name = mapping.TableName;
            tableInfo.Schema = mapping.Schema;
            tableInfo.ClrType = entity.ClrType;
            tableInfo.Columns = GetColumns(tableInfo);
            tableInfo.PrimaryKey = GetPrimaryKeyInfo(tableInfo);

            return tableInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<ColumnInfo> GetColumns(EFTableInfo table)
        {
            var props = table.Entity.GetProperties();
            return props.Select(s => GetColumn(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private ColumnInfo GetColumn(EFTableInfo table, IProperty property)
        {
            var columnRelational = property.Relational();

            var column = new ColumnInfo();
            column.Table = table;
            column.Name = columnRelational.ColumnName;
            column.Type = TypeInfoCreator?.Create(property);
            column.IsAllowNull = property.IsNullable;
            column.DefaultValue = columnRelational.DefaultValue;

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private PrimaryKeyInfo GetPrimaryKeyInfo(EFTableInfo table)
        {
            var primary = table.Entity.FindPrimaryKey();
            var primaryRelational = primary?.Relational();
            if (primaryRelational == null)
                return null;

            var result = new PrimaryKeyInfo();
            result.Name = primaryRelational.Name;
            result.Table = table;

            var prop = primary.Properties?.FirstOrDefault();
            var name = prop?.Relational()?.ColumnName;
            result.PrimaryColumn = table.GetColumn(name);

            return result;
        }
    }
}
