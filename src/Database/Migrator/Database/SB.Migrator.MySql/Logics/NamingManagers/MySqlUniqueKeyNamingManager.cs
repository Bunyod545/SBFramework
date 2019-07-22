using System.Linq;
using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.MySql.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlUniqueKeyNamingManager : IUniqueKeyNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueKey"></param>
        public void Correct(UniqueKeyInfo uniqueKey)
        {
            uniqueKey.Name = string.IsNullOrEmpty(uniqueKey.Name)
                ? "UC_" + uniqueKey.Table.Name + "_" + string.Join("_", uniqueKey.UniqueColumns.Select(s => s.Name))
                : uniqueKey.Name;
        }
    }
}
