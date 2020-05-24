namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnAttribute : System.ComponentModel.DataAnnotations.Schema.ColumnAttribute
    {
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
