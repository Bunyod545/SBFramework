using System.Collections.Generic;
using SB.Migrator.Logics.Database.Interfaces;
using SB.Migrator.Postgres.ResxFiles;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresTableManager : PostgresBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PostgresTable> PostgresTables { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        public PostgresTableManager(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PostgresTable> GetTables()
        {
            return PostgresTables ?? new List<PostgresTable>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeTables()
        {
            PostgresTables = new List<PostgresTable>();
            var command = GetPostgresCommand(Scripts.SelectTables);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                PostgresTables.Add(new PostgresTable(reader["schemaname"] as string, reader["tablename"] as string));

            const string name = MigrationsHistoryRepositoryHelper.HistoryTable;
            const string schema = MigrationsHistoryRepositoryHelper.HistoryTableSchema;
            PostgresTables.RemoveAll(r => r.Name == name && r.Schema == schema);
        }
    }
}
