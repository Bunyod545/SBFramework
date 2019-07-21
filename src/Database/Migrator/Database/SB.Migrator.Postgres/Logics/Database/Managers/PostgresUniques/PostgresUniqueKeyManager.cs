using System.Collections.Generic;
using System.Linq;
using Npgsql;
using SB.Common.Extensions;
using SB.Migrator.Postgres.ResxFiles;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresUniqueKeyManager : PostgresBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<PostgresUniqueKey> PostgresUniqueKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public PostgresUniqueKeyManager(PostgresDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void InitializeUniqueKeys()
        {
            PostgresUniqueKeys = new List<PostgresUniqueKey>();
            var command = GetPostgresCommand(Scripts.SelectUniqueKeys);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                PostgresUniqueKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private PostgresUniqueKey ReaderToPrimaryKey(NpgsqlDataReader reader)
        {
            return new PostgresUniqueKey
            {
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                ColumnName = reader["Column_Name"] as string,
                ConstraintName = reader["Constraint_Name"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<PostgresUniqueKeyInfo> GetUniqueKeys(PostgresTable table)
        {
            var keys = PostgresUniqueKeys.ToList(w => w.TableName == table.Name && w.TableSchema == table.Schema);
            return keys.GroupBy(g => g.ConstraintName).Select(s => new PostgresUniqueKeyInfo(s)).ToList();
        }
    }
}
