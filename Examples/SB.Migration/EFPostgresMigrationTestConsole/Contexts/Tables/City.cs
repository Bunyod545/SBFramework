namespace EFPostgresMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// City infos
    /// </summary>
    public class City
    {
        /// <summary>
        /// City identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City owner Country
        /// </summary>
        public long OwnerId { get; set; }

        /// <summary>
        /// City owner Country
        /// </summary>
        public virtual Country Owner { get; set; }
    }
}
