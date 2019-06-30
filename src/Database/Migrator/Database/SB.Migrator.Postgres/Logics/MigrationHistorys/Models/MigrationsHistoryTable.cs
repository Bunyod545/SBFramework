namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class MigrationsHistoryTable
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Version2 { get; set; }
    }
}
