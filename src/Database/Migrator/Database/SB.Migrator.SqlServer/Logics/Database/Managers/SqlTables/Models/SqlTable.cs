namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlTable
    {
        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SqlTable()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        public SqlTable(string schema, string name)
        {
            Schema = schema;
            Name = name;
        }
    }
}
