using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresColumnDefaultValueCommand : PostgresColumnCommand, IColumnDefaultValueCommand
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
