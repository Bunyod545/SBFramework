using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SB.Migrator.Models;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlForeignKeyManager
    {
        /// <summary>
        /// 
        /// </summary>
        internal static List<SqlForeignKey> SqlForeignKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void InitializeForeignKeys()
        {
            SqlForeignKeys = new List<SqlForeignKey>();
            var command = SqlCommandHelper.GetSqlCommand(Scripts.SelectForeignKeys);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                SqlForeignKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static SqlForeignKey ReaderToPrimaryKey(SqlDataReader reader)
        {
            return new SqlForeignKey
            {
                ConstraintName = reader["CONSTRAINT_NAME"] as string,
                TableSchema = reader["REFERENCING_TABLE_SCHEMA_NAME"] as string,
                TableName = reader["REFERENCING_TABLE_NAME"] as string,
                ColumnName = reader["REFERENCING_COLUMN_NAME"] as string,
                ReferencedTableSchema = reader["REFERENCED_TABLE_SCHEMA_NAME"] as string,
                ReferencedTableName = reader["REFERENCED_TABLE_NAME"] as string,
                ReferencedColumnName = reader["REFERENCED_COLUMN_NAME"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<SqlForeignKey> GetForeignKeys(TableInfo table)
        {
            if (SqlForeignKeys == null)
                return new List<SqlForeignKey>();

            return SqlForeignKeys.Where(f =>
                f.TableSchema == table.Schema &&
                f.TableName == table.Name).ToList();
        }
    }
}
