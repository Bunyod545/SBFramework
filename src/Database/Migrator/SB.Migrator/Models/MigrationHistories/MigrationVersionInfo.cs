namespace SB.Migrator.Models.MigrationHistories
{
    /// <summary>
    /// 
    /// </summary>
    public class MigrationVersionInfo
    {
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
        public MigrationVersionInfo()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public MigrationVersionInfo(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
