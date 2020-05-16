using Npgsql;
using SB.Migrator.Logics.Database.Interfaces;

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
        public IDatabaseConnection DatabaseConnection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        protected PostgresBaseMappingManager(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public NpgsqlCommand GetPostgresCommand(string commandText)
        {
            var connection = new NpgsqlConnection(DatabaseConnection.ConnectionString);
            connection.Open();

            return new NpgsqlCommand(commandText, connection);
        }
    }
}
