using SB.Migrator.Models;

namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITableNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        void Correct(TableInfo table);
    }
}