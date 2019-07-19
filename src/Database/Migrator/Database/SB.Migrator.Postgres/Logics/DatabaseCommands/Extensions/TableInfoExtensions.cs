using SB.Migrator.Models;

namespace SB.Migrator.Postgres
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
        public static string GetPgSqlNewName(this TableInfo tableInfo)
        {
            return $"{tableInfo.Schema}.\"{tableInfo.NewName}\"";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public static string GetPgSqlName(this TableInfo tableInfo)
        {
            return $"{tableInfo.Schema}.\"{tableInfo.Name}\"";
        }
    }
}
