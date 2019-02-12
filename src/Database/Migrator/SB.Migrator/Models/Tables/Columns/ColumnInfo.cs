using System;

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
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }

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
        public int? CharacterMaximumLenght { get; set; }

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
        /// <returns></returns>
        public bool IsPrimary()
        {
            return Table?.PrimaryKey?.PrimaryColumn == this;
        }
    }
}
