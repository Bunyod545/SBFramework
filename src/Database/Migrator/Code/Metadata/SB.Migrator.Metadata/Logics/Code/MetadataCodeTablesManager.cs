﻿using System;
using System.Collections.Generic;
using System.Linq;
using SB.Common.Extensions;
using SB.Migrator.Logics.Code;
using SB.Migrator.Metadata.Logics.Code.Models;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.MigrationHistorys;
using SB.Migrator.Models.Scripts;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Values;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataCodeTablesManager : CodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<MetadataTableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        public MetadataManager MetadataManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public MetadataCodeTablesManager(MigrateManager migrateManager) : base(migrateManager)
        {
            MetadataManager = new MetadataManager(migrateManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<ScriptInfo> GetBeforeActualizationScripts()
        {
            var scripts = MetadataManager.GetBeforeActualizationScripts();
            return scripts.Select(s => (ScriptInfo)new MetadataScriptInfo(s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<ScriptInfo> GetAfterActualizationScripts()
        {
            var scripts = MetadataManager.GetAfterActualizationScripts();
            return scripts.Select(s => (ScriptInfo)new MetadataScriptInfo(s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<TableInfo> GetTableInfos()
        {
            var codeTables = MetadataManager.GetTables();
            _tableInfos = codeTables.Select(GetTableInfo).ToList();
            _tableInfos.ForEach(f => f.ForeignKeys = GetForeignKeys(f));

            return _tableInfos.Select(s => (TableInfo)s).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        private MetadataTableInfo GetTableInfo(TableMetadata tableMetadata)
        {
            var tableInfo = new MetadataTableInfo();
            tableInfo.TableMetadata = tableMetadata;
            tableInfo.Name = tableMetadata.Name;
            tableInfo.Schema = tableMetadata.Schema ?? MigrateManager.DatabaseTablesManager?.DefaultSchema;
            tableInfo.Columns = GetColumns(tableInfo, tableMetadata);
            tableInfo.PrimaryKey = GetPrimaryKey(tableInfo, tableMetadata);
            tableInfo.TableValues = GetTableValues(tableInfo, tableMetadata);

            return tableInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        private List<ColumnInfo> GetColumns(TableInfo tableInfo, TableMetadata tableMetadata)
        {
            return tableMetadata.Columns.Select(c => GetColumn(tableInfo, c)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="columnMetadata"></param>
        /// <returns></returns>
        private ColumnInfo GetColumn(TableInfo tableInfo, ColumnMetadata columnMetadata)
        {
            var columnInfo = new ColumnInfo();
            columnInfo.Table = tableInfo;
            columnInfo.IsAllowNull = columnMetadata.IsAllowNull;
            columnInfo.Name = columnMetadata.Name;
            columnInfo.DefaultValue = columnMetadata.DefaultValue;
            columnInfo.Identity = GetColumnIdentity(columnMetadata);
            columnInfo.Type = new MetadataColumnTypeInfo(this, columnMetadata);

            return columnInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnMetadata"></param>
        /// <returns></returns>
        private Identity GetColumnIdentity(ColumnMetadata columnMetadata)
        {
            var isPrimary = columnMetadata.Property.IsHasAttribute<PrimaryKeyAttribute>();
            return isPrimary ? new Identity(1, 1) : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        private PrimaryKeyInfo GetPrimaryKey(MetadataTableInfo tableInfo, TableMetadata tableMetadata)
        {
            var primaryKeyMetadata = tableMetadata.PrimaryKey;
            if (primaryKeyMetadata == null)
                return null;

            var primaryKey = new PrimaryKeyInfo();
            primaryKey.Table = tableInfo;
            primaryKey.Name = primaryKeyMetadata.Name;
            primaryKey.PrimaryColumn = tableInfo.GetColumn(primaryKeyMetadata.PrimaryColumn?.Name);

            return primaryKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<TableValueInfo> GetTableValues(TableInfo tableInfo, TableMetadata tableMetadata)
        {
            var result = new List<TableValueInfo>();
            foreach (var valueMetadata in tableMetadata.TableValues)
            {
                var value = new TableValueInfo();
                value.Table = tableInfo;
                value.ValueItems = GetTableValueItems(valueMetadata, tableInfo);

                result.Add(value);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueMetadata"></param>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        private List<TableValueItemInfo> GetTableValueItems(TableValueMetadata valueMetadata, TableInfo tableInfo)
        {
            var valueItems = new List<TableValueItemInfo>();
            foreach (var valueItemMetadata in valueMetadata.ValueItems)
            {
                var valueItem = new TableValueItemInfo();
                valueItem.Value = valueItemMetadata.Value;
                valueItem.Column = tableInfo.GetColumn(valueItemMetadata.Column?.Name);

                valueItems.Add(valueItem);
            }

            return valueItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<ForeignKeyInfo> GetForeignKeys(MetadataTableInfo table)
        {
            var forignKeys = table.TableMetadata.ForeignKeys;
            return forignKeys.Select(s => GetForeignKey(table, s)).ToList(w => w != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="foreignKeyMetadata"></param>
        /// <returns></returns>
        private ForeignKeyInfo GetForeignKey(MetadataTableInfo table, ForeignKeyMetadata foreignKeyMetadata)
        {
            var foreignKey = new ForeignKeyInfo();
            foreignKey.Name = foreignKeyMetadata.Name;
            foreignKey.Column = table.GetColumn(foreignKeyMetadata.Column.Name);
            foreignKey.Table = table;

            var referencedTable = foreignKeyMetadata.ReferencedTable;
            foreignKey.ReferenceTable = _tableInfos.FirstOrDefault(f => f.TableMetadata.TableType == referencedTable);
            foreignKey.ReferenceColumn = GetReferenceColumn(foreignKey, foreignKeyMetadata);

            return foreignKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        /// <param name="foreignKeyMetadata"></param>
        /// <returns></returns>
        private ColumnInfo GetReferenceColumn(ForeignKeyInfo foreignKey, ForeignKeyMetadata foreignKeyMetadata)
        {
            var referenceColumn = foreignKeyMetadata.ReferencedColumn;
            if (string.IsNullOrEmpty(referenceColumn))
                return foreignKey?.ReferenceTable?.PrimaryKey?.PrimaryColumn;

            return foreignKey.ReferenceTable.GetColumn(referenceColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<MigrationVersionInfo> GetMigrationVersionInfos()
        {
            return MetadataManager.Assemblies.Select(s => new MigrationVersionInfo
            {
                Name = s.MigrateName,
                Version = s.MigrateVersion
            }).ToList();
        }
    }
}