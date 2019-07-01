using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

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
        public ColumnInfo DatabaseColumn { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        public void SetDatabaseColumn(ColumnInfo column)
        {
            DatabaseColumn = column;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            SetAlterTable();
            ScriptBuilder.Append(" ALTER COLUMN");
            SetColumnInfo();
        }
    }
}
