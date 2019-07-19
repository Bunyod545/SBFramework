using SB.Migrator.Models;

namespace SB.Migrator.SqlServer
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
        public static string GetSqlNewName(this TableInfo tableInfo)
        {
            return $"[{tableInfo.Schema}].[{tableInfo.NewName}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public static string GetSqlName(this TableInfo tableInfo)
        {
            return $"[{tableInfo.Schema}].[{tableInfo.Name}]";
        }
    }
}
