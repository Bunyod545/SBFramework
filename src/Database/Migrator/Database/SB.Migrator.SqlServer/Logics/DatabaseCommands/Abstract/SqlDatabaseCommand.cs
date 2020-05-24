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
        public string ConnectionString { get; set; }

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
        public virtual void Execute()
        {
            var command = GetSqlCommand();
            command.ExecuteNonQuery();

            command.Connection.Close();
            command.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual SqlCommand GetSqlCommand()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return new SqlCommand(CommandText, connection);
        }
    }
}
