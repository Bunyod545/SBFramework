using System.Text;
using MySql.Data.MySqlClient;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MySqlDatabaseCommand : IDatabaseCommand
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

            command.Connection?.Close();
            command.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        protected virtual MySqlCommand GetSqlCommand(string connectionString)
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            return new MySqlCommand(CommandText, connection);
        }
    }
}
