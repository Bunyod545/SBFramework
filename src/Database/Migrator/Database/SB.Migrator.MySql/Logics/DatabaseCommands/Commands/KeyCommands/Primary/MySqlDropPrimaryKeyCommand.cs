using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlDropPrimaryKeyCommand : MySqlPrimaryKeyCommand, IDropPrimaryKeyCommand
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
            ScriptBuilder.Append(Table.GetMySqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" DROP CONSTRAINT");
            ScriptBuilder.Append($" {GetPrimaryKeyName()}");
        }
    }
}
