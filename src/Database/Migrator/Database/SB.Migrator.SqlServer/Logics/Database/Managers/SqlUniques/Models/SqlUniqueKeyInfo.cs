using System.Collections.Generic;
using System.Linq;

namespace SB.Migrator.SqlServer 
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlUniqueKeyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public List<SqlUniqueKey> SqlUniqueKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UniqueName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SqlUniqueKeyInfo()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniques"></param>
        public SqlUniqueKeyInfo(IGrouping<string, SqlUniqueKey> uniques)
        {
            UniqueName = uniques.Key;
            SqlUniqueKeys = uniques.ToList();
        }
    }
}
