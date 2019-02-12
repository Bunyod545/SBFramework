using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlTableCommand : SqlDatabaseCommand, ITableCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public virtual void SetTable(TableInfo info)
        {
            Table = info;
        }
    }
}
