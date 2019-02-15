using System.Data.SqlClient;
using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlDatabaseCommand : IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual int Order { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public string CommandText { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        protected StringBuilder ScriptBuilder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BuildCommandText()
        {
            InternalBuildCommandText();
            CommandText = ScriptBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract void InternalBuildCommandText();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public virtual void Execute(string connectionString)
        {
            var command = GetSqlCommand(connectionString);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private SqlCommand GetSqlCommand(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return new SqlCommand(CommandText, connection);
        }
    }
}
