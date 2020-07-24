using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SB.Common.Logics.Business;

namespace EFSqlMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Countries")]
    public class Country : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(500)]
        public override string Name { get; set; }
    }
}
