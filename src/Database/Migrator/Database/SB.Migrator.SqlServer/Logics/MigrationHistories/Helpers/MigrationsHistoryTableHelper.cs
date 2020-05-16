using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Columns;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class MigrationsHistoryTableHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ColumnInfo GetIdColumn()
        {
            var idColumn = new ColumnInfo();
            idColumn.Type = new ColumnTypeInfo("bigint");
            idColumn.Identity = new Identity(1, 1);
            idColumn.IsAllowNull = false;
            idColumn.Name = nameof(MigrationsHistoryTable.Id);

            return idColumn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ColumnInfo GetNameColumn()
        {
            return GetTextColumn(nameof(MigrationsHistoryTable.Name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ColumnInfo GetVersionColumn()
        {
            return GetTextColumn(nameof(MigrationsHistoryTable.Version));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ColumnInfo GetVersion2Column()
        {
            return GetTextColumn(nameof(MigrationsHistoryTable.Version2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ColumnInfo GetTextColumn(string name)
        {
            var column = new ColumnInfo();
            column.Type = new ColumnTypeInfo("nvarchar(max)");
            column.IsAllowNull = true;
            column.Name = name;

            return column;
        }
    }
}
