using SB.Migrator.Metadata;

namespace MetadataMySqlMigrationTestConsole.Database.Tables
{
    /// <summary>
    /// City table
    /// </summary>
    [Table("cities")]
    public class City
    {   
        /// <summary>
        /// City identifier
        /// </summary>
        [Column, PrimaryKey]
        public long Id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// City disegned name
        /// </summary>
        [Column]
        public string DesignedName { get; set; }

        /// <summary>
        /// City owner country
        /// </summary>
        [Column, ForeignKey]
        public Country Owner { get; set; }
    }
}
