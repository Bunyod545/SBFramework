namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlPrimaryKey
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConstraintName { get; set; }
    }
}
