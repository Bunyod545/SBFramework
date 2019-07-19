namespace SB.Migrator.Models.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class KeyInfo
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
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Table} {Name}";
        }
    }
}
