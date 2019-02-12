using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropPrimaryKeyCommand : SqlPrimaryKeyCommand, ICreatePrimaryKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append($"[{PrimaryKey.Table.Schema}].[{PrimaryKey.Table.Name}]");

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" DROP CONSTRAINT");
            ScriptBuilder.Append($" {GetPrimaryKeyName()}");
        }
    }
}
