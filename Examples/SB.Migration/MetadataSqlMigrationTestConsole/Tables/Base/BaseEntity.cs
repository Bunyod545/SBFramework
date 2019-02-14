using SB.Common.Logics.Business;
using SB.Migrator.Metadata;

namespace MetadataSqlMigrationTestConsole.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseEntity : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column, PrimaryKey]
        public override long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public override string Name { get; set; }
    }
}
