using System.Collections.Generic;
using System.Linq;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresUniqueKeyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PostgresUniqueKey> SqlUniqueKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UniqueName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PostgresUniqueKeyInfo()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniques"></param>
        public PostgresUniqueKeyInfo(IGrouping<string, PostgresUniqueKey> uniques)
        {
            UniqueName = uniques.Key;
            SqlUniqueKeys = uniques.ToList();
        }
    }
}
