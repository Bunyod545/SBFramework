using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SB.Migrator.EntityFramework.Code.Logics.TableFinders.Helpers;
using SB.Migrator.EntityFramework.Code.Logics.TableFinders.Models;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.MigrationHistories;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class TableFinder : ITableFinder
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMigrationsHistoryRepository _historyRepository;

        /// <summary>
        /// 
        /// </summary>
        private List<TableContextInfo> _contextInfos;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMigrateManager _migrateManager;

        /// <summary>
        /// 
        /// </summary>
        private readonly IDatabaseTablesManager _databaseTablesManager;

        /// <summary>
        /// 
        /// </summary>
        private List<EFTableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="historyRepository"></param>
        /// <param name="migrateManager"></param>
        /// <param name="databaseTablesManager"></param>
        public TableFinder(IMigrationsHistoryRepository historyRepository, IMigrateManager migrateManager, IDatabaseTablesManager databaseTablesManager)
        {
            _historyRepository = historyRepository;
            _migrateManager = migrateManager;
            _databaseTablesManager = databaseTablesManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetTableInfos()
        {
            _contextInfos = GetContexts();
            _tableInfos = _contextInfos.SelectMany(GetTable).ToList();
            _tableInfos.ForEach(f => f.ForeignKeys = GetForeignKeys(f));

            var tables = _tableInfos.GroupBy(g => g.ClrType).Select(s => s.FirstOrDefault());
            return tables.Select(s => (TableInfo)s).ToList();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<TableContextInfo> GetContexts()
        {
            var histories = _historyRepository.GetMigrationHistories();
            var contexts = TableContextFinderHelper.GetContexts();

            return contexts.Where(w => IsCanMigrate(w, histories)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextInfo"></param>
        /// <param name="histories"></param>
        /// <returns></returns>
        private bool IsCanMigrate(TableContextInfo contextInfo, List<MigrationHistory> histories)
        {
            var history = histories.FirstOrDefault(f => f.Name == contextInfo.ContextType.Name);
            if (history == null)
                return true;

            var historyVersion = new Version(history.Version);
            return historyVersion < contextInfo.MigrateVersion;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextInfo"></param>
        /// <returns></returns>
        private List<EFTableInfo> GetTable(TableContextInfo contextInfo)
        {
            if (!(Activator.CreateInstance(contextInfo.ContextType) is DbContext context))
                return new List<EFTableInfo>();

            var entityTypes = contextInfo.TableTypes.Select(context.Model.FindEntityType);
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
            tableInfo.Schema = mapping.Schema ?? _databaseTablesManager.DefaultSchema;
            tableInfo.ClrType = entity.ClrType;
            tableInfo.Description = entity.ClrType.GetSummary();
            _migrateManager.CorrectName(tableInfo);

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
            column.Description = property.PropertyInfo.GetSummary();
            column.Type = new EFColumnTypeInfo(property);
            column.IsAllowNull = property.IsNullable;
            column.DefaultValue = columnRelational.DefaultValue;
            column.Identity = GetIdentity(property);

            _migrateManager.CorrectName(column);
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

            _migrateManager.CorrectName(result);
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

                _migrateManager.CorrectName(uniqueInfo);
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

            _migrateManager.CorrectName(result);
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
            var schema = entity.Schema ?? _databaseTablesManager.DefaultSchema;
            var tableName = entity.TableName;

            return _tableInfos.FirstOrDefault(f => f.Schema == schema && f.Name == tableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MigrationVersionInfo> GetMigrationVersionInfos()
        {
            return _contextInfos
                .Select(s => new MigrationVersionInfo(s.ContextType.Name, s.MigrateVersion.ToString()))
                .ToList();
        }
    }
}
