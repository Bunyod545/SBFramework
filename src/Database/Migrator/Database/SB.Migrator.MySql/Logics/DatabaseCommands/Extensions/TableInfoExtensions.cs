using SB.Migrator.Models;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public static class TableInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public static string GetMySqlNewName(this TableInfo tableInfo)
        {
            return $"{tableInfo.Schema}.{tableInfo.NewName}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public static string GetMySqlName(this TableInfo tableInfo)
        {
            return $"{tableInfo.Schema}.{tableInfo.Name}";
        }
    }
}
