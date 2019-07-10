using System.Collections.Generic;
using System.Linq;
using Npgsql;
using SB.Migrator.Postgres.ResxFiles;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresPrimaryKeyManager : MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<PostgresPrimaryKey> PostgresPrimaryKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public PostgresPrimaryKeyManager(MySqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void InitializePrimaryKeys()
        {
            PostgresPrimaryKeys = new List<PostgresPrimaryKey>();
            var command = GetPostgresCommand(Scripts.SelectPrimaryKeys);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                PostgresPrimaryKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private PostgresPrimaryKey ReaderToPrimaryKey(NpgsqlDataReader reader)
        {
            return new PostgresPrimaryKey
            {
                TableSchema = reader["table_schema"] as string,
                TableName = reader["table_name"] as string,
                ColumnName = reader["column_name"] as string,
                ConstraintName = reader["constraint_name"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public PostgresPrimaryKey GetPrimaryKey(PostgresTable table)
        {
            return PostgresPrimaryKeys?.FirstOrDefault(f =>
                f.TableSchema == table.Schema &&
                f.TableName == table.Name);
        }
    }
}
