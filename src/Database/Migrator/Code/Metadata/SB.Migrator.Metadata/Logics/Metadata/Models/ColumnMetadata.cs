using System.Reflection;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Decription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableMetadata Table { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAllowNull { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }
    }
}
