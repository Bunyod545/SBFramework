using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUniqueKeyNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueKey"></param>
        void Correct(UniqueKeyInfo uniqueKey);
    }
}