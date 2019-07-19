using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresRenameTableCommand : PostgresTableCommand, IRenameTableCommand
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
            ScriptBuilder.AppendFormat(Table.GetPgSqlName());

            ScriptBuilder.Append("RENAME TO ");
            ScriptBuilder.AppendFormat(Table.GetPgSqlNewName());
        }
    }
}
