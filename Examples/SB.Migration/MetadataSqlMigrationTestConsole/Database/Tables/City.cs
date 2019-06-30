using SB.Migrator.Metadata;

namespace MetadataSqlMigrationTestConsole.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Citys")]
    public class City
    {   
        /// <summary>
        /// 
        /// </summary>
        [Column, PrimaryKey]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string DesignedName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column, ForeignKey(typeof(Country))]
        public long OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IgnoreColumn]
        public Country Owner { get; set; }
    }
}
