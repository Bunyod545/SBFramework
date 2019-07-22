using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IForeignKeyNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        void Correct(ForeignKeyInfo foreignKey);
    }
}