using System.ComponentModel.DataAnnotations.Schema;
using SB.Common.Logics.Business;

namespace EFSqlMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Cities")]
    public class City : Entity, IOwned
    {
        /// <summary>
        /// 
        /// </summary>
        public long OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Country Owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Test { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEntity IOwned.Owner
        {
            get => Owner;
            set => Owner = (Country)value;
        }
    }
}
