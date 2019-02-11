using System.Data.SqlClient;
using SB.Migrator.Helpers;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCommandHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static SqlCommand GetSqlCommand(string commandText)
        {
            var connection = new SqlConnection(MigrateHelper.ConnectionString);
            connection.Open();

            return new SqlCommand(commandText, connection);
        }
    }
}
