namespace SB.Migrator.Models.Tables.Columns
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetColumnType()
        {
            return Type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Type;
    }
}
