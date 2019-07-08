namespace EFPostgresMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class City
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
        public long OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Country Owner { get; set; }
    }
}
