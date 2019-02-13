using SB.Migrator.Models.Column;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public static class ColumnInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumn"></param>
        /// <returns></returns>
        public static bool IsMustRenameColumn(this ColumnInfo codeColumn, ColumnInfo databaseColumn)
        {
            return !string.IsNullOrEmpty(codeColumn.NewName) &&
                   codeColumn.NewName != databaseColumn.Name;
        }
    }
}
