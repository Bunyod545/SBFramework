using System.ComponentModel.DataAnnotations.Schema;
using SBCommon.Logics.Business;

namespace SB.EntityFramework.Context.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Types", Schema = "SB")]
    public class SbType : IIdentified
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPrimitive { get; set; }
    }
}
