using System.ComponentModel.DataAnnotations;
using SB.Common.Logics.Business;

namespace EFSqlMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class Country : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(500)]
        public override string Name { get; set; }
    }
}
