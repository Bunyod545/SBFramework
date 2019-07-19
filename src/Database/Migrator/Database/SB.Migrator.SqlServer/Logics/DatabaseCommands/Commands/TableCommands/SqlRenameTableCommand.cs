using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlRenameTableCommand : SqlTableCommand, IRenameTableCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.RenameTable;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.AppendFormat(Table.GetSqlName());

            ScriptBuilder.Append("RENAME TO ");
            ScriptBuilder.AppendFormat(Table.GetSqlNewName());
        }
    }
}
