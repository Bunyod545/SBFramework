using System.Text;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlAlterColumnCommand : SqlColumnCommand, IAlterColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.AlterColumn;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.AppendFormat("[{0}].[{1}]", Column.Table.Schema, Column.Table.Name);

            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendFormat("ALTER COLUMN [{0}] {1}", Column.Name, Column.Type.GetColumnType());
        }
    }
}
