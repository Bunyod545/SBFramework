﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlPrimaryKeyManager
    {
        /// <summary>
        /// 
        /// </summary>
        internal static List<SqlPrimaryKey> SqlPrimaryKeys { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void InitializePrimaryKeys()
        {
            SqlPrimaryKeys = new List<SqlPrimaryKey>();
            var command = SqlCommandHelper.GetSqlCommand(Scripts.SelectPrimaryKeys);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                SqlPrimaryKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static SqlPrimaryKey ReaderToPrimaryKey(SqlDataReader reader)
        {
            return new SqlPrimaryKey
            {
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                ColumnName = reader["COLUMN_NAME"] as string,
                ConstraintName = reader["CONSTRAINT_NAME"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static SqlPrimaryKey GetPrimaryKey(SqlTable table)
        {
            return SqlPrimaryKeys?.FirstOrDefault(f =>
                f.TableSchema == table.Schema &&
                f.TableName == table.Name);
        }
    }
}
