using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlColumnDefaultValueCommand :SqlColumnCommand, IColumnDefaultValueCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetConstraintName()
        {
            return $" [DF_{Column}]";
        }
    }
}
