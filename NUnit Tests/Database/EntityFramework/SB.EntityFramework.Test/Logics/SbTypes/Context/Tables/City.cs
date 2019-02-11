using System.ComponentModel.DataAnnotations.Schema;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;
using SB.Common.Logics.Business;

namespace SB.EntityFramework.Test.Logics.SbTypes.Context.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table(TableName, Schema = EFContext.DefaultSchema)]
    public class City : Entity, IOwned
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TableName = "Cities";

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SbType GetSbType()
        {
            return new SbType()
            {
                Name = TableName,
                Prefix = EFContext.DefaultSchema
            };
        }
    }
}
