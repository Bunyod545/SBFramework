using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MySqlColumnDefaultValueCommand : MySqlColumnCommand, IColumnDefaultValueCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetConstraintName()
        {
            return $" DF_{Column}";
        }
    }
}
