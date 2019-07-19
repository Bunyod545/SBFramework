using System.Text;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresRenameColumnCommand : PostgresColumnCommand, IRenameColumnCommand
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
            ScriptBuilder.Append($"{Table.GetPgSqlName()}.{Column.GetPgSqlName()} ");

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append($"{Column.GetPgSqlNewName()} ");

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append("'COLUMN'");
        }
    }
}
