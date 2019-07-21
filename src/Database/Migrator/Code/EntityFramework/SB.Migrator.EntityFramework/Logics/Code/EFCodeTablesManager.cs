﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SB.Migrator.EntityFramework.Logics.Code.Logics.MigrationValidators;
using SB.Migrator.Logics.Code;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.MigrationHistorys;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFCodeTablesManager : CodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<EFTableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public EFCodeTablesManager(MigrateManager migrateManager) : base(migrateManager)
        {
            MigrateManager.Validator = new EntityFrameworkMigrationValidator(migrateManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<TableInfo> GetTableInfos()
        {
            _tableInfos = GetTables();
            _tableInfos.ForEach(f=> f.ForeignKeys = GetForeignKeys(f));

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
            if (!(Activator.CreateInstance(contextType) is DbContext context))
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
        private EFTableInfo ConvertToTableInfo(DbContext context, IEntityType entity)
        {
            var mapping = entity.Relational();

            var tableInfo = new EFTableInfo();
            tableInfo.Context = context;
            tableInfo.Entity = entity;
            tableInfo.Name = mapping.TableName;
            tableInfo.Schema = mapping.Schema ?? MigrateManager.DatabaseTablesManager?.DefaultSchema;
            tableInfo.ClrType = entity.ClrType;
            tableInfo.Decription = entity.ClrType.GetSummary();
            tableInfo.Columns = GetColumns(tableInfo);
            tableInfo.PrimaryKey = GetPrimaryKeyInfo(tableInfo);
            tableInfo.UniqueKeys = GetUniqueKeys(tableInfo).ToList();

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
            column.Decription = property.PropertyInfo.GetSummary();
            column.Type = new EFColumnTypeInfo(property);
            column.IsAllowNull = property.IsNullable;
            column.DefaultValue = columnRelational.DefaultValue;
            column.Identity = GetIdentity(property);

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Identity GetIdentity(IProperty property)
        {
            return property.IsPrimaryKey() ? new Identity(1, 1) : null;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private IEnumerable<UniqueKeyInfo> GetUniqueKeys(EFTableInfo table)
        {
            var indexes = table.Entity.GetIndexes().Where(w => w.IsUnique).ToList();
            foreach (var index in indexes)
            {
                var uniqueInfo = new UniqueKeyInfo();
                uniqueInfo.Table = table;
                uniqueInfo.Name = index.Relational()?.Name;
                uniqueInfo.UniqueColumns = index.Properties.Select(s => GetUniqueColumn(table, s)).ToList();

                yield return uniqueInfo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private ColumnInfo GetUniqueColumn(EFTableInfo table, IProperty property)
        {
            return table.GetColumn(property.Relational().ColumnName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<ForeignKeyInfo> GetForeignKeys(EFTableInfo table)
        {
            var foreignKeys = table.Entity.GetForeignKeys();
            return foreignKeys.Select(s => GetForeignKey(s, table)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private ForeignKeyInfo GetForeignKey(IForeignKey foreignKey, EFTableInfo table)
        {
            var result = new ForeignKeyInfo();
            result.Table = table;
            result.Name = foreignKey.Relational().Name;
            result.Column = table.GetColumn(foreignKey.GetColumnName());

            result.ReferenceTable = GetReferenceTable(foreignKey);
            result.ReferenceColumn = result.ReferenceTable.GetColumn(foreignKey.GetReferenceColumnName());
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private EFTableInfo GetReferenceTable(IForeignKey key)
        {
            var entity = key.PrincipalEntityType.Relational();
            return _tableInfos.FirstOrDefault(f => f.Schema == entity.Schema && f.Name == entity.TableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<MigrationVersionInfo> GetMigrationVersionInfos()
        {
            return new List<MigrationVersionInfo>();
        }
    }
}
