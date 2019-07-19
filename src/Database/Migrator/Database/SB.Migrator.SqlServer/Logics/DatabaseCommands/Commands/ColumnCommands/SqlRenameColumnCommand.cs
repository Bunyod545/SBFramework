using System.Text;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlRenameColumnCommand : SqlColumnCommand, IRenameColumnCommand
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
            ScriptBuilder.Append($"{Table.GetSqlName()}.{Column.GetSqlName()} ");

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append($"{Column.GetSqlName()} ");

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append("'COLUMN'");
        }
    }
}
