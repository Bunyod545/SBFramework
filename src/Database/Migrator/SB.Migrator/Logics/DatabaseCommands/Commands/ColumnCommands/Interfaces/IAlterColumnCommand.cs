using SB.Migrator.Models.Column;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAlterColumnCommand : IColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        ColumnInfo DatabaseColumn { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        void SetDatabaseColumn(ColumnInfo column);
    }
}
