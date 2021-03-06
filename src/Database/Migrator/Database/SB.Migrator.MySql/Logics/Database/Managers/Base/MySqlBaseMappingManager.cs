﻿using MySql.Data.MySqlClient;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public MySqlDatabaseTablesManager DatabaseTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        protected MySqlBaseMappingManager(MySqlDatabaseTablesManager databaseTablesManager)
        {
            DatabaseTablesManager = databaseTablesManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public MySqlCommand GetMySqlCommand(string commandText)
        {
            var connection = new MySqlConnection(DatabaseTablesManager.DatabaseConnection.ConnectionString);
            connection.Open();

            return new MySqlCommand(commandText, connection);
        }
    }
}
