using System.Reflection;

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
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAllowNull { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsHasPrimaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsHasForeignKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }
    }
}
