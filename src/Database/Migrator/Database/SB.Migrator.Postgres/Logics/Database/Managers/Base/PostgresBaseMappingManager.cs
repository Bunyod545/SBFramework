using Npgsql;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public PostgresDatabaseTablesManager DatabaseTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        protected PostgresBaseMappingManager(PostgresDatabaseTablesManager databaseTablesManager)
        {
            DatabaseTablesManager = databaseTablesManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public NpgsqlCommand GetPostgresCommand(string commandText)
        {
            var connection = new NpgsqlConnection(DatabaseTablesManager.MigrateManager.ConnectionString);
            connection.Open();

            return new NpgsqlCommand(commandText, connection);
        }
    }
}
