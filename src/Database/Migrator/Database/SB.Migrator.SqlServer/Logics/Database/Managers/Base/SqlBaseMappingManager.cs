using System.Data.SqlClient;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public SqlDatabaseTablesManager DatabaseTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        protected SqlBaseMappingManager(SqlDatabaseTablesManager databaseTablesManager)
        {
            DatabaseTablesManager = databaseTablesManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public SqlCommand GetSqlCommand(string commandText)
        {
            var connection = new SqlConnection(DatabaseTablesManager.MigrateManager.ConnectionString);
            connection.Open();

            return new SqlCommand(commandText, connection);
        }
    }
}
