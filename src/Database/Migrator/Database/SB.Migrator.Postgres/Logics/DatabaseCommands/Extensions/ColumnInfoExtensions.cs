using SB.Migrator.Models.Column;

namespace SB.Migrator.Postgres
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
        public static string GetPgSqlNewName(this ColumnInfo columnInfo)
        {
            return $"\"{columnInfo.NewName}\"";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnInfo"></param>
        /// <returns></returns>
        public static string GetPgSqlName(this ColumnInfo columnInfo)
        {
            return $"\"{columnInfo.Name}\"";
        }
    }
}
