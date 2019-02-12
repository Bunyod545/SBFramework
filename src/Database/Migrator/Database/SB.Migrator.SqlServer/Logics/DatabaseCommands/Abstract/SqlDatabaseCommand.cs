using System.Text;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlDatabaseCommand
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
        public virtual void Execute()
        {
            var command = SqlCommandHelper.GetSqlCommand(CommandText);
            command.ExecuteNonQuery();
        }
    }
}
