using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropColumnCommand : SqlColumnCommand, IDropColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropColumn;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            SetAlterTable();
            ScriptBuilder.Append($"DROP COLUMN [{Column.Name}]");
        }
    }
}
