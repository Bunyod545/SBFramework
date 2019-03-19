namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class TableValueItemMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnMetadata Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Column.Name} = {Value}";
        }
    }
}
