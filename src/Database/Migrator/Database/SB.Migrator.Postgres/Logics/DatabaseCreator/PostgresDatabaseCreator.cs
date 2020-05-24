using System;
using Npgsql;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.Database.Interfaces;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresDatabaseCreator : DatabaseCreator
    {
        /// <summary>
        /// 
        /// </summary>
        protected NpgsqlConnectionStringBuilder Connection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        public PostgresDatabaseCreator(IDatabaseConnection databaseConnection) 
        {
            Connection = new NpgsqlConnectionStringBuilder(databaseConnection.ConnectionString);
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
        protected NpgsqlCommand GetSqlCommand(string commandText)
        {
            var masterDbConnection = new NpgsqlConnectionStringBuilder(Connection.ConnectionString);
            masterDbConnection.Database = "postgres";

            var connection = new NpgsqlConnection(masterDbConnection.ConnectionString);
            connection.Open();

            return new NpgsqlCommand(commandText, connection);
        }
    }
}
