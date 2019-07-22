using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.MySql.Logics.NamingManagers;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlDatabaseTablesManager : DatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<TableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        public override string DefaultSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected MySqlTableManager MySqlTableManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected MySqlColumnManager MySqlColumnManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected MySqlPrimaryKeyManager MySqlPrimaryKeyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected MySqlForeignKeyManager MySqlForeignKeyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public MySqlDatabaseTablesManager(MigrateManager migrateManager) : base(migrateManager)
        {
            MigrateManager.DatabaseCreator = new MySqlDatabaseCreator(migrateManager);
            MigrateManager.MigrationsHistoryRepository = new MySqlMigrationsHistoryRepository(migrateManager);
            MigrateManager.NamingManager.ForeignKeyNamingManager = new MySqlForeignKeyNamingManager();
            MigrateManager.NamingManager.PrimaryKeyNamingManager = new MySqlPrimaryKeyNamingManager();
            MigrateManager.NamingManager.UniqueKeyNamingManager = new MySqlUniqueKeyNamingManager();

            MigrateManager.DatabaseCommandManager.UseMySqlCommands();
            ColumnTypeMappingSource = new MySqlColumnTypeMappingSource();

            MySqlTableManager = new MySqlTableManager(this);
            MySqlColumnManager = new MySqlColumnManager(this);
            MySqlPrimaryKeyManager = new MySqlPrimaryKeyManager(this);
            MySqlForeignKeyManager = new MySqlForeignKeyManager(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            DefaultSchema = GetDatabaseName();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDatabaseName()
        {
            return new MySqlConnectionStringBuilder(MigrateManager.ConnectionString).Database;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<TableInfo> GetTableInfos()
        {
            MySqlTableManager.InitializeTables();
            MySqlColumnManager.InitializeColumns();
            MySqlPrimaryKeyManager.InitializePrimaryKeys();
            MySqlForeignKeyManager.InitializeForeignKeys();

            var postgresTables = MySqlTableManager.GetTables();
            _tableInfos = postgresTables.Select(ConvertToTableInfo).ToList();
            _tableInfos.ForEach(FillForeignKeyInfos);

            return _tableInfos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private TableInfo ConvertToTableInfo(MySqlTable postgresTable)
        {
            var table = new TableInfo();
            table.Schema = postgresTable.Schema;
            table.Name = postgresTable.Name;
            table.Columns = GetColumns(table, postgresTable);
            table.PrimaryKey = GetPrimaryKeyInfo(table, postgresTable);

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private List<ColumnInfo> GetColumns(TableInfo table, MySqlTable postgresTable)
        {
            var columns = MySqlColumnManager.GetSqlColumns(postgresTable);
            return columns.Select(s => ConvertToColumnInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresColumn"></param>
        /// <returns></returns>
        private ColumnInfo ConvertToColumnInfo(TableInfo table, MySqlColumn postgresColumn)
        {
            var column = new ColumnInfo();
            column.Name = postgresColumn.Name;
            column.DefaultValue = GetDefaultValue(postgresColumn);
            column.IsAllowNull = postgresColumn.IsNullable;
            column.Type = new MySqlColumnTypeInfo(postgresColumn);
            column.Table = table;

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private object GetDefaultValue(MySqlColumn column)
        {
            return column.DefaultValue is DBNull ? null : column.DefaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresTable"></param>
        /// <returns></returns>
        private PrimaryKeyInfo GetPrimaryKeyInfo(TableInfo table, MySqlTable postgresTable)
        {
            var sqlPrimaryKey = MySqlPrimaryKeyManager.GetPrimaryKey(postgresTable);
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
        /// <returns></returns>
        private void FillForeignKeyInfos(TableInfo table)
        {
            var sqlForeignKeys = MySqlForeignKeyManager.GetForeignKeys(table);
            table.ForeignKeys = sqlForeignKeys.Select(s => ConvertToForeignKeyInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="postgresForeignKey"></param>
        /// <returns></returns>
        private ForeignKeyInfo ConvertToForeignKeyInfo(TableInfo table, MySqlForeignKey postgresForeignKey)
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
