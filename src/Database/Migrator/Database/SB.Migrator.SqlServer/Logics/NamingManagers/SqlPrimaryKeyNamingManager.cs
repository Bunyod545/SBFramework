using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.SqlServer.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlPrimaryKeyNamingManager : IPrimaryKeyNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        public void Correct(PrimaryKeyInfo primaryKey)
        {
            primaryKey.Name = string.IsNullOrEmpty(primaryKey.Name) ? $"PK_{primaryKey.Table.Name}" : primaryKey.Name;
        }
    }
}
