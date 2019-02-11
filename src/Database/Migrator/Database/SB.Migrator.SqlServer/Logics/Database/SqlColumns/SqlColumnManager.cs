﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlColumnManager
    {
        /// <summary>
        /// 
        /// </summary>
        internal static List<SqlColumn> SqlColumns { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public static void InitializeColumns()
        {
            SqlColumns = new List<SqlColumn>();
            var command = SqlCommandHelper.GetSqlCommand(Scripts.SelectColumns);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                SqlColumns.Add(ReaderToColumn(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static SqlColumn ReaderToColumn(SqlDataReader reader)
        {
            return new SqlColumn
            {
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                Name = reader["COLUMN_NAME"] as string,
                Position = (int)reader["ORDINAL_POSITION"],
                DefaultValue = reader["COLUMN_DEFAULT"],
                IsNullable = reader["IS_NULLABLE"]?.ToString() == "YES",
                DataType = reader["DATA_TYPE"] as string,
                CharacterMaximumLenght = reader["CHARACTER_MAXIMUM_LENGTH"] as int?,
                CharacterOctetLenght = reader["CHARACTER_OCTET_LENGTH"] as int?,
                NumericPrecision = reader["NUMERIC_PRECISION"] as int?,
                NumericPrecisionRadix = reader["NUMERIC_PRECISION_RADIX"] as int?,
                NumericScale = reader["NUMERIC_SCALE"] as int?,
                DateTimePrecision = reader["DATETIME_PRECISION"] as int?,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        public static List<SqlColumn> GetSqlColumns(SqlTable sqlTable)
        {
            if (SqlColumns == null)
                return new List<SqlColumn>();

            return SqlColumns.Where(w =>
                w.TableSchema == sqlTable.Schema &&
                w.TableName == sqlTable.Name).ToList();
        }
    }
}
