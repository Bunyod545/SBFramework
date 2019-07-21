namespace SB.Migrator.Metadata.Logics.Metadata.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumTableMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        [Column, PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string Synonym { get; set; }
    }
}
