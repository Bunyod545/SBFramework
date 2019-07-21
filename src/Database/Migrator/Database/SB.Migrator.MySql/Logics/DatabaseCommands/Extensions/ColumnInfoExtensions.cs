using SB.Migrator.Models.Column;

namespace SB.Migrator.MySql
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
        public static string GetMySqlNewName(this ColumnInfo columnInfo)
        {
            return $"{columnInfo.NewName}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnInfo"></param>
        /// <returns></returns>
        public static string GetMySqlName(this ColumnInfo columnInfo)
        {
            return $"{columnInfo.Name}";
        }
    }
}
