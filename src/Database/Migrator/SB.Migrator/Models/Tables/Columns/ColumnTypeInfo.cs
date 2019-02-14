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
        public ColumnTypeInfo()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public ColumnTypeInfo(string type)
        {
            Type = type;
        }

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
