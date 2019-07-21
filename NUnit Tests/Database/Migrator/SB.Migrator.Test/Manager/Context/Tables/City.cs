using System.ComponentModel.DataAnnotations.Schema;
using SB.Common.Logics.Business;

namespace SB.EntityFramework.Test.Logics.SbTypes.Context.Tables
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
        public Country Owner { get; set; }

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
