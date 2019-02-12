using SB.Migrator.Models.Column;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        ColumnInfo Column { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        void SetColumn(ColumnInfo column);
    }
}
