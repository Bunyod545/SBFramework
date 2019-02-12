using SB.Migrator.Models.Column;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlTypeManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string GetColumnType(ColumnInfo column)
        {
            if (!string.IsNullOrEmpty(column.Type))
                return column.Type;

            return string.Empty;
        }
    }
}
