﻿using System;
using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Logics.ServiceContainers;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;
using SB.Migrator.Postgres.Logics.NamingManagers;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresDatabaseTablesManager : DatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<TableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        public override string DefaultSchema => "public";

        /// <summary>
        /// 
        /// </summary>
        public IMigrateServicesContainer ServicesContainer { get; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresTableManager PostgresTableManager { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresColumnManager PostgresColumnManager { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresPrimaryKeyManager PostgresPrimaryKeyManager { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresUniqueKeyManager PostgresUniqueKeyManager { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresForeignKeyManager PostgresForeignKeyManager { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicesContainer"></param>
        public PostgresDatabaseTablesManager(IMigrateServicesContainer servicesContainer)
        {
            ServicesContainer = servicesContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            var namingManager = ServicesContainer.GetService<INamingManager>();
            namingManager.ForeignKeyNamingManager = new PostgresForeignKeyNamingManager();
            namingManager.PrimaryKeyNamingManager = new PostgresPrimaryKeyNamingManager();
            namingManager.UniqueKeyNamingManager = new PostgresUniqueKeyNamingManager();

            PostgresTableManager = ServicesContainer.GetService<PostgresTableManager>();
            PostgresColumnManager = ServicesContainer.GetService<PostgresColumnManager>();
            PostgresPrimaryKeyManager = ServicesContainer.GetService<PostgresPrimaryKeyManager>();
            PostgresUniqueKeyManager = ServicesContainer.GetService<PostgresUniqueKeyManager>();
            PostgresForeignKeyManager = ServicesContainer.GetService<PostgresForeignKeyManager>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<TableInfo> GetTableInfos()
        {
            PostgresTableManager.InitializeTables();
            PostgresColumnManager.InitializeColumns();
            PostgresPrimaryKeyManager.InitializePrimaryKeys();
            PostgresForeignKeyManager.InitializeForeignKeys();
            PostgresUniqueKeyManager.InitializeUniqueKeys();

            var postgresTables = PostgresTableManager.GetTables();
            _tableInfos = postgresTables.Select(ConvertToTableInfo).ToList();
            _tableInfos.ForEach(FillForeignKeyInfos);

            return _tableInfos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private TableInfo ConvertToTableInfo(PostgresTable postgresTable)
        {
            var table = new TableInfo();
            table.Schema = postgresTable.Schema;
            table.Name = postgresTable.Name;
            table.Columns = GetColumns(table, postgresTable);
            table.PrimaryKey = GetPrimaryKeyInfo(table, postgresTable);
            table.UniqueKeys = GetUniques(table, postgresTable);

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private List<ColumnInfo> GetColumns(TableInfo table, PostgresTable postgresTable)
        {
            var columns = PostgresColumnManager.GetSqlColumns(postgresTable);
            return columns.Select(s => ConvertToColumnInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresColumn"></param>
        /// <returns></returns>
        private ColumnInfo ConvertToColumnInfo(TableInfo table, PostgresColumn postgresColumn)
        {
            var column = new ColumnInfo();
            column.Name = postgresColumn.Name;
            column.DefaultValue = GetDefaultValue(postgresColumn);
            column.IsAllowNull = postgresColumn.IsNullable;
            column.Type = new PostgresColumnTypeInfo(postgresColumn);
            column.Table = table;

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private object GetDefaultValue(PostgresColumn column)
        {
            return column.DefaultValue is DBNull ? null : column.DefaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private PrimaryKeyInfo GetPrimaryKeyInfo(TableInfo table, PostgresTable postgresTable)
        {
            var sqlPrimaryKey = PostgresPrimaryKeyManager.GetPrimaryKey(postgresTable);
            if (sqlPrimaryKey == null)
                return null;

            var primaryKey = new PrimaryKeyInfo();
            primaryKey.Name = sqlPrimaryKey.ConstraintName;
            primaryKey.Table = table;
            primaryKey.PrimaryColumn = table.GetColumn(sqlPrimaryKey.ColumnName);
            return primaryKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private List<UniqueKeyInfo> GetUniques(TableInfo table, PostgresTable postgresTable)
        {
            return PostgresUniqueKeyManager
                .GetUniqueKeys(postgresTable)
                .Select(s => GetUnique(table, s))
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresUniqueKey"></param>
        /// <returns></returns>
        private UniqueKeyInfo GetUnique(TableInfo table, PostgresUniqueKeyInfo postgresUniqueKey)
        {
            var unique = new UniqueKeyInfo();
            unique.Table = table;
            unique.Name = postgresUniqueKey.UniqueName;
            unique.UniqueColumns = postgresUniqueKey.SqlUniqueKeys.Select(s => table.GetColumn(s.ColumnName)).ToList();

            return unique;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private void FillForeignKeyInfos(TableInfo table)
        {
            var sqlForeignKeys = PostgresForeignKeyManager.GetForeignKeys(table);
            table.ForeignKeys = sqlForeignKeys.Select(s => ConvertToForeignKeyInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresForeignKey"></param>
        /// <returns></returns>
        private ForeignKeyInfo ConvertToForeignKeyInfo(TableInfo table, PostgresForeignKey postgresForeignKey)
        {
            var foreignKey = new ForeignKeyInfo();
            foreignKey.Name = postgresForeignKey.ConstraintName;
            foreignKey.Table = table;
            foreignKey.Column = table.GetColumn(postgresForeignKey.ColumnName);
            foreignKey.ReferenceTable = _tableInfos.FirstOrDefault(postgresForeignKey.IsReferenceTable);
            foreignKey.ReferenceColumn = foreignKey.ReferenceTable?.Columns.FirstOrDefault(postgresForeignKey.IsReferenceColumn);

            return foreignKey;
        }
    }
}
