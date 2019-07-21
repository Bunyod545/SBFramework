using System.Text;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlRenameColumnCommand : MySqlColumnCommand, IRenameColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.RenameColumn;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("sp_rename ");
            ScriptBuilder.Append($"{Table.GetMySqlName()}.{Column.GetMySqlName()} ");

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append(Column.GetMySqlNewName());

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append("'COLUMN'");
        }
    }
}
