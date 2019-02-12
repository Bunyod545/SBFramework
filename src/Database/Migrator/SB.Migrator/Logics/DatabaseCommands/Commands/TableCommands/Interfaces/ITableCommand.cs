using SB.Migrator.Models;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITableCommand : IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        TableInfo Table { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        void SetTable(TableInfo table);
    }
}