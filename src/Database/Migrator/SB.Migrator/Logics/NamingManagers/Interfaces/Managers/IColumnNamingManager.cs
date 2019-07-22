using SB.Migrator.Models.Column;

namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IColumnNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        void Correct(ColumnInfo column);
    }
}