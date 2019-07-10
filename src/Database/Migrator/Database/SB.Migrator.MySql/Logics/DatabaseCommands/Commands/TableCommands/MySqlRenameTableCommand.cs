using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlRenameTableCommand : MySqlTableCommand, IRenameTableCommand
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
            ScriptBuilder.AppendFormat("{0}.\"{1}\"", Table.Schema, Table.Name);

            ScriptBuilder.Append("RENAME TO ");
            ScriptBuilder.AppendFormat("{0}.\"{1}\"", Table.Schema, Table.NewName);
        }
    }
}
