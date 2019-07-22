using System;
using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;
using SB.Migrator.SqlServer.Logics.ColumnTypeMappingSource;
using SB.Migrator.SqlServer.Logics.NamingManagers;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDatabaseTablesManager : DatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<TableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        public override string DefaultSchema => "dbo";

        /// <summary>
        /// 
        /// </summary>
        protected SqlTableManager SqlTableManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected SqlColumnManager SqlColumnManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected SqlUniqueKeyManager SqlUniqueKeyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected SqlPrimaryKeyManager SqlPrimaryKeyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected SqlForeignKeyManager SqlForeignKeyManager { get; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public SqlDatabaseTablesManager(MigrateManager migrateManager) : base(migrateManager)
        {
            MigrateManager.DatabaseCreator = new SqlDatabaseCreator(migrateManager);
            MigrateManager.MigrationsHistoryRepository = new SqlMigrationsHistoryRepository(migrateManager);
            MigrateManager.NamingManager.ForeignKeyNamingManager = new SqlForeignKeyNamingManager();
            MigrateManager.NamingManager.PrimaryKeyNamingManager = new SqlPrimaryKeyNamingManager();
            MigrateManager.NamingManager.UniqueKeyNamingManager = new SqlUniqueKeyNamingManager();

            MigrateManager.DatabaseCommandManager.UseSqlCommands();
            ColumnTypeMappingSource = new SqlColumnTypeMappingSource();

            SqlTableManager = new SqlTableManager(this);
            SqlColumnManager = new SqlColumnManager(this);
            SqlUniqueKeyManager = new SqlUniqueKeyManager(this);
            SqlPrimaryKeyManager = new SqlPrimaryKeyManager(this);
            SqlForeignKeyManager = new SqlForeignKeyManager(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<TableInfo> GetTableInfos()
        {
            SqlTableManager.InitializeTables();
            SqlColumnManager.InitializeColumns();
            SqlUniqueKeyManager.InitializeUniqueKeys();
            SqlPrimaryKeyManager.InitializePrimaryKeys();
            SqlForeignKeyManager.InitializeForeignKeys();

            var sqlTables = SqlTableManager.GetTables();
            _tableInfos = sqlTables.Select(ConvertToTableInfo).ToList();
            _tableInfos.ForEach(FillForeignKeyInfos);

            return _tableInfos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        private TableInfo ConvertToTableInfo(SqlTable sqlTable)
        {
            var table = new TableInfo();
            table.Schema = sqlTable.Schema;
            table.Name = sqlTable.Name;
            table.Columns = GetColumns(table, sqlTable);
            table.UniqueKeys = GetUniqueKeys(table, sqlTable);
            table.PrimaryKey = GetPrimaryKeyInfo(table, sqlTable);

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        private List<ColumnInfo> GetColumns(TableInfo table, SqlTable sqlTable)
        {
            var columns = SqlColumnManager.GetSqlColumns(sqlTable);
            return columns.Select(s => ConvertToColumnInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        private ColumnInfo ConvertToColumnInfo(TableInfo table, SqlColumn sqlColumn)
        {
            var column = new ColumnInfo();
            column.Name = sqlColumn.Name;
            column.DefaultValue = GetDefaultValue(sqlColumn);
            column.IsAllowNull = sqlColumn.IsNullable;
            column.Type = new SqlColumnTypeInfo(sqlColumn);
            column.Table = table;

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        private List<UniqueKeyInfo> GetUniqueKeys(TableInfo table, SqlTable sqlTable)
        {
            var uniqueKeys = SqlUniqueKeyManager.GetUniqueKeys(sqlTable);
            return uniqueKeys.Select(s => ConvertToUniqueInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlUniqueKey"></param>
        /// <returns></returns>
        private UniqueKeyInfo ConvertToUniqueInfo(TableInfo table, SqlUniqueKeyInfo sqlUniqueKey)
        {
            var uniqueKey = new UniqueKeyInfo();
            uniqueKey.Table = table;
            uniqueKey.Name = sqlUniqueKey.UniqueName;
            uniqueKey.UniqueColumns = ConvertToUniqueColumnInfo(table, sqlUniqueKey).ToList();

            return uniqueKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlUniqueKey"></param>
        /// <returns></returns>
        private IEnumerable<ColumnInfo> ConvertToUniqueColumnInfo(TableInfo table, SqlUniqueKeyInfo sqlUniqueKey)
        {
            foreach (var uniqueKey in sqlUniqueKey.SqlUniqueKeys)
            {
                var column = table.GetColumn(uniqueKey.ColumnName);
                if (column != null)
                    yield return column;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private object GetDefaultValue(SqlColumn column)
        {
            return column.DefaultValue is DBNull ? null : column.DefaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        private PrimaryKeyInfo GetPrimaryKeyInfo(TableInfo table, SqlTable sqlTable)
        {
            var sqlPrimaryKey = SqlPrimaryKeyManager.GetPrimaryKey(sqlTable);
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
            var sqlForeignKeys = SqlForeignKeyManager.GetForeignKeys(table);
            table.ForeignKeys = sqlForeignKeys.Select(s => ConvertToForeignKeyInfo(table, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sqlForeignKey"></param>
        /// <returns></returns>
        private ForeignKeyInfo ConvertToForeignKeyInfo(TableInfo table, SqlForeignKey sqlForeignKey)
        {
            var foreignKey = new ForeignKeyInfo();
            foreignKey.Name = sqlForeignKey.ConstraintName;
            foreignKey.Table = table;
            foreignKey.Column = table.GetColumn(sqlForeignKey.ColumnName);
            foreignKey.ReferenceTable = _tableInfos.FirstOrDefault(sqlForeignKey.IsReferenceTable);
            foreignKey.ReferenceColumn = foreignKey.ReferenceTable?.Columns.FirstOrDefault(sqlForeignKey.IsReferenceColumn);

            return foreignKey;
        }
    }
}
