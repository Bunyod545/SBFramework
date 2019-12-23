using FirebirdSql.Data.FirebirdClient;
using SB.Migrator.Logics.Database;

namespace SB.Migrator.Firebird
{
    /// <summary>
    /// 
    /// </summary>
    public class FirebirdDatabaseCreator : DatabaseCreator
    {
        /// <summary>
        /// 
        /// </summary>
        protected FbConnectionStringBuilder Connection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public FirebirdDatabaseCreator(MigrateManager migrateManager) : base(migrateManager)
        {
            Connection = new FbConnectionStringBuilder(migrateManager.ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDatabaseExists()
        {
            var command = GetSqlCommand($"SELECT datname FROM pg_catalog.pg_database WHERE datname = '{Connection.Database}'");
            return command.ExecuteScalar() != null;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CreateDatabase()
        {
            var command = GetSqlCommand($"CREATE DATABASE \"{Connection.Database}\"");
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected FbCommand GetSqlCommand(string commandText)
        {
            var masterDbConnection = new FbConnectionStringBuilder(Connection.ConnectionString);
            masterDbConnection.Database = "postgres";

            var connection = new FbConnection(masterDbConnection.ConnectionString);
            connection.Open();

            return new FbCommand(commandText, connection);
        }
    }
}
