using SB.Migrator.Metadata;

namespace MetadataSqlMigrationTestConsole.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Citys")]
    public class City : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string DesignedName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column, ForeignKey]
        public Country Owner { get; set; }
    }
}
