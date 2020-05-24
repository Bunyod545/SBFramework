using System.Data.SqlClient;
using SB.Migrator.Logics.Database.Interfaces;

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
        protected IDatabaseConnection DatabaseConnection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        protected SqlBaseMappingManager(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public SqlCommand GetSqlCommand(string commandText)
        {
            var connection = new SqlConnection(DatabaseConnection.ConnectionString);
            connection.Open();

            return new SqlCommand(commandText, connection);
        }
    }
}
