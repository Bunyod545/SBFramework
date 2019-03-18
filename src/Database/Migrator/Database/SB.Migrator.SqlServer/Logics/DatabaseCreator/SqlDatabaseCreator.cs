using System;
using System.Data.SqlClient;
using SB.Migrator.Logics.Database;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDatabaseCreator : DatabaseCreator
    {
        /// <summary>
        /// 
        /// </summary>
        protected SqlConnectionStringBuilder Connection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public SqlDatabaseCreator(MigrateManager migrateManager) : base(migrateManager)
        {
            Connection = new SqlConnectionStringBuilder(migrateManager.ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDatabaseExists()
        {
            var command = GetSqlCommand($"SELECT DB_ID('{Connection.InitialCatalog}')");
            return !(command.ExecuteScalar() is DBNull);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CreateDatabase()
        {
            var command = GetSqlCommand($"CREATE DATABASE {Connection.InitialCatalog}");
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected SqlCommand GetSqlCommand(string commandText)
        {
            var masterDbConnection = new SqlConnectionStringBuilder(Connection.ConnectionString);
            masterDbConnection.InitialCatalog = "master";

            var connection = new SqlConnection(masterDbConnection.ConnectionString);
            connection.Open();

            return new SqlCommand(commandText, connection);
        }
    }
}
