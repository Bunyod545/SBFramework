using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.SqlServer.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDatabaseTablesManager : IDatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<TableInfo> _tableInfos;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetTableInfos()
        {
            SqlTableManager.InitializeTables();
            SqlColumnManager.InitializeColumns();
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
            column.DefaultValue = sqlColumn.DefaultValue;
            column.IsAllowNull = sqlColumn.IsNullable;
            column.Type = sqlColumn.DataType;
            column.Table = table;

            return column;
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
            foreignKey.ReferenceColumn = foreignKey.Table?.Columns.FirstOrDefault(sqlForeignKey.IsReferenceColumn);

            return foreignKey;
        }
    }
}
