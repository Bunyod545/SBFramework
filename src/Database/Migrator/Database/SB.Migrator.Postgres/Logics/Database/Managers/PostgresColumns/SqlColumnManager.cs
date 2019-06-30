using System.Collections.Generic;
using System.Linq;
using Npgsql;
using SB.Migrator.Postgres.ResxFiles;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresColumnManager : PostgresBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<PostgresColumn> PostgresColumns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public PostgresColumnManager(PostgresDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeColumns()
        {
            PostgresColumns = new List<PostgresColumn>();
            var command = GetPostgresCommand(Scripts.SelectColumns);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                PostgresColumns.Add(ReaderToColumn(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private PostgresColumn ReaderToColumn(NpgsqlDataReader reader)
        {
            return new PostgresColumn
            {
                TableSchema = reader["table_schema"] as string,
                TableName = reader["table_name"] as string,
                Name = reader["column_name"] as string,
                Position = (int)reader["ordinal_position"],
                DefaultValue = reader["column_default"],
                IsNullable = reader["is_nullable"]?.ToString() == "YES",
                DataType = reader["data_type"] as string,
                CharacterMaximumLenght = reader["character_maximum_length"] as int?,
                CharacterOctetLenght = reader["character_octet_length"] as int?,
                NumericPrecision = reader["numeric_precision"] as int?,
                NumericPrecisionRadix = reader["numeric_precision_radix"] as int?,
                NumericScale = reader["numeric_scale"] as int?,
                DateTimePrecision = reader["datetime_precision"] as int?,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        public List<PostgresColumn> GetSqlColumns(PostgresTable sqlTable)
        {
            if (PostgresColumns == null)
                return new List<PostgresColumn>();

            return PostgresColumns.Where(w =>
                w.TableSchema == sqlTable.Schema &&
                w.TableName == sqlTable.Name).ToList();
        }
    }
}
