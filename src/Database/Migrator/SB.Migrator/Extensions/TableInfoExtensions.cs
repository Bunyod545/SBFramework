using System.Collections.Generic;
using SB.Common.Extensions;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class TableInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<ColumnInfo> GetAdditionalColumns(this TableInfo table)
        {
            return table.Columns.ToList(w => w != table.GetPrimaryColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetPrimaryColumnName(this TableInfo table)
        {
            return table.GetPrimaryColumn()?.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static ColumnInfo GetPrimaryColumn(this TableInfo table)
        {
            return table?.PrimaryKey?.PrimaryColumn;
        }
    }
}
