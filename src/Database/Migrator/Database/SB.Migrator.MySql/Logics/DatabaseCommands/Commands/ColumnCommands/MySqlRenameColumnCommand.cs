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
            ScriptBuilder.AppendFormat("{0}.\"{1}\".\"{2}\" ", 
                Column.Table.Schema, 
                Column.Table.Name, 
                Column.Name);

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.AppendFormat("\"{0}\" ", Column.NewName);

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append("'COLUMN'");
        }
    }
}
