using System;
using System.Data.SqlClient;
using System.Text;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlScriptCommand : SqlDatabaseCommand, IScriptCommand
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
        public SqlTransaction Transaction { get; private set; }

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
        protected override SqlCommand GetSqlCommand(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            Transaction = connection.BeginTransaction();

            var command = new SqlCommand(CommandText, connection);
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
                Transaction.Commit();
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
        }
    }
}
