using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsNullable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAllowNull
        {
            get => IsNullable.GetValueOrDefault();
            set => IsNullable = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }
    }
}
