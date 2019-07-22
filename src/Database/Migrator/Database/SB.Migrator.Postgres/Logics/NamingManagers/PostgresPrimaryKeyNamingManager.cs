using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Postgres.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresPrimaryKeyNamingManager : IPrimaryKeyNamingManager
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
