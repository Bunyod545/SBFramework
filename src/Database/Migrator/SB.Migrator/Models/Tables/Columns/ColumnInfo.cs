using System;
using SB.Migrator.Models.Tables.Columns;

namespace SB.Migrator.Models.Column
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnTypeInfo Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAllowNull { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsPrimary()
        {
            return Table?.PrimaryKey?.PrimaryColumn == this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Table}.{Name}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column1"></param>
        /// <param name="column2"></param>
        /// <returns></returns>
        public static bool operator ==(ColumnInfo column1, ColumnInfo column2)
        {
            if (Equals(column1, null) || Equals(column2, null))
                return false;

            return column1.Name == column2.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column1"></param>
        /// <param name="column2"></param>
        /// <returns></returns>
        public static bool operator !=(ColumnInfo column1, ColumnInfo column2)
        {
            return !(column1 == column2);
        }
    }
}
