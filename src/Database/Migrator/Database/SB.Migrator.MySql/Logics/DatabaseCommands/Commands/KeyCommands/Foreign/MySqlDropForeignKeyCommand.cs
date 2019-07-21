using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlDropForeignKeyCommand : MySqlForeignKeyCommand, IDropForeignKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropForeignKey;

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
            ScriptBuilder.Append($" {GetForeignKeyName()}");
        }
    }
}
