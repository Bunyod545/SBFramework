using SB.Migrator.Models.Column;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class ColumnInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnInfo"></param>
        /// <returns></returns>
        public static string GetSqlNewName(this ColumnInfo columnInfo)
        {
            return $"[{columnInfo.NewName}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnInfo"></param>
        /// <returns></returns>
        public static string GetSqlName(this ColumnInfo columnInfo)
        {
            return $"[{columnInfo.Name}]";
        }
    }
}
