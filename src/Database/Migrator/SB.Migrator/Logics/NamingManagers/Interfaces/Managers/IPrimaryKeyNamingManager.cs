using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrimaryKeyNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        void Correct(PrimaryKeyInfo primaryKey);
    }
}