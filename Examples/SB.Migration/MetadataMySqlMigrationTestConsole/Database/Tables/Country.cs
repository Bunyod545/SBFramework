using SB.Migrator.Metadata;

namespace MetadataMySqlMigrationTestConsole.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("countrys")]
    public class Country 
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
    }
}
