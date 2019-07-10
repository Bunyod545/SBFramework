using System;
using System.Text;
using MySql.Data.MySqlClient;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MySqlScriptCommand : MySqlDatabaseCommand, IScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] Separator => new[] { "GO\r" };

        /// <summary>
        /// 
        /// </summary>
        public ScriptInfo ScriptInfo { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public MySqlTransaction Transaction { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptInfo"></param>
        public void SetScript(ScriptInfo scriptInfo)
        {
            ScriptInfo = scriptInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append(ScriptInfo.ScriptText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        protected override MySqlCommand GetSqlCommand(string connectionString)
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            Transaction = connection.BeginTransaction();

            var command = new MySqlCommand(CommandText, connection);
            command.Transaction = Transaction;
            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public override void Execute(string connectionString)
        {
            try
            {
                InternalExecute(connectionString);
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                Transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InternalExecute(string connectionString)
        {
            var command = GetSqlCommand(connectionString);
            var commandTexts = CommandText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (var commandText in commandTexts)
            {
                if (string.IsNullOrEmpty(commandText))
                    continue;

                command.CommandText = commandText;
                command.ExecuteNonQuery();
            }

            Transaction.Commit();
            command.Connection?.Close();
            command.Dispose();
        }
    }
}
