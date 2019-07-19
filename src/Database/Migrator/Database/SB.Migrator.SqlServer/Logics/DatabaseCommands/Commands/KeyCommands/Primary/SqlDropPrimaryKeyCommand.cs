using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropPrimaryKeyCommand : SqlPrimaryKeyCommand, IDropPrimaryKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropPrimaryKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append(Table.GetSqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" DROP CONSTRAINT");
            ScriptBuilder.Append($" {GetPrimaryKeyName()}");
        }
    }
}
