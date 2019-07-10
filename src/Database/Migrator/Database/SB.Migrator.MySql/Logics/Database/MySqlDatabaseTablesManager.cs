using System;
using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Postgres;

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
        public override string DefaultSchema => "public";

        /// <summary>
        /// 
        /// </summary>
        protected PostgresTableManager MySqlTableManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected MySqlColumnManager MySqlColumnManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresPrimaryKeyManager MySqlPrimaryKeyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected PostgresForeignKeyManager MySqlForeignKeyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public MySqlDatabaseTablesManager(MigrateManager migrateManager) : base(migrateManager)
        {
            MigrateManager.DatabaseCreator = new MySqlDatabaseCreator(migrateManager);
            MigrateManager.MigrationsHistoryRepository = new MySqlMigrationsHistoryRepository(migrateManager);
            MigrateManager.DatabaseCommandManager.UseMySqlCommands();
            ColumnTypeMappingSource = new MySqlColumnTypeMappingSource();

            MySqlTableManager = new PostgresTableManager(this);
            MySqlColumnManager = new MySqlColumnManager(this);
            MySqlPrimaryKeyManager = new PostgresPrimaryKeyManager(this);
            MySqlForeignKeyManager = new PostgresForeignKeyManager(this);
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
        private TableInfo ConvertToTableInfo(PostgresTable postgresTable)
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
        private List<ColumnInfo> GetColumns(TableInfo table, PostgresTable postgresTable)
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
        private PrimaryKeyInfo GetPrimaryKeyInfo(TableInfo table, PostgresTable postgresTable)
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
