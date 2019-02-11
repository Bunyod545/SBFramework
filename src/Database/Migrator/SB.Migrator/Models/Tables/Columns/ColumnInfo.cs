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
        public string Type { get; set; }

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
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Table}.{Name}";
        }
    }
}
