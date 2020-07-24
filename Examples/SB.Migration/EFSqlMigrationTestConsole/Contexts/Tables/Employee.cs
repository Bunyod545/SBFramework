using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SB.Common.Logics.Business;

namespace EFSqlMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Employees")]
    public class Employee : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(500)]
        public override string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long CountryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long CityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public City City { get; set; }
    }
}
