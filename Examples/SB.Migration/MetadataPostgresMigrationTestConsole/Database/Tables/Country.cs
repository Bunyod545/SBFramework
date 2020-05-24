using SB.Migrator.Metadata;

namespace MetadataPostgresMigrationTestConsole.Database.Tables
{
    /// <summary>
    /// Countries
    /// </summary>
    [Table("Countries")]
    public class Country 
    {      
        /// <summary>
        /// Country identifier
        /// </summary>
        [Column, PrimaryKey]
        public long Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Country designed name
        /// </summary>
        [Column]
        public string DesignedName { get; set; }

        /// <summary>
        /// Country test name
        /// </summary>
        [Column]
        public string TestName { get; set; }
    }
}
