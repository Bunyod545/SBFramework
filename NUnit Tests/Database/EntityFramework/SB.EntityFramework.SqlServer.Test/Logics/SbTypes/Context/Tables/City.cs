using System.ComponentModel.DataAnnotations.Schema;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;
using SBCommon.Logics.Business;

namespace SB.EntityFramework.SqlServer.Test.Logics.SbTypes
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
        public const string TableName = "Citys";

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
            set => Owner = (Country) value;
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
