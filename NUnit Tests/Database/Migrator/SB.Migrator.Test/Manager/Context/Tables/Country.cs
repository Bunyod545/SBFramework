using System.ComponentModel.DataAnnotations.Schema;
using SB.EntityFramework.Context;
using SB.Common.Logics.Business;

namespace SB.EntityFramework.Test.Logics.SbTypes
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Countries", Schema = EFContext.DefaultSchema)]
    public class Country : Entity
    {
       
    }
}
