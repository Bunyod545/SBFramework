using MySql.Data.MySqlClient;
using SB.Migrator.Logics.Database;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlDatabaseCreator : DatabaseCreator
    {
        /// <summary>
        /// 
        /// </summary>
        protected MySqlConnectionStringBuilder Connection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public MySqlDatabaseCreator(MigrateManager migrateManager) : base(migrateManager)
        {
            Connection = new MySqlConnectionStringBuilder(migrateManager.ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDatabaseExists()
        {
            var command = GetSqlCommand($"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{Connection.Database}'");
            return command.ExecuteScalar() != null;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CreateDatabase()
        {
            var command = GetSqlCommand($"CREATE DATABASE {Connection.Database} CHARACTER SET utf8 COLLATE utf8_bin;");
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected MySqlCommand GetSqlCommand(string commandText)
        {
            var sysDbConnection = new MySqlConnectionStringBuilder(Connection.ConnectionString);
            sysDbConnection.Database = "sys";

            var connection = new MySqlConnection(sysDbConnection.ConnectionString);
            connection.Open();

            return new MySqlCommand(commandText, connection);
        }
    }
}
