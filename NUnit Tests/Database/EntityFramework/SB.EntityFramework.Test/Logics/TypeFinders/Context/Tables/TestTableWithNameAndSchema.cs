using System.ComponentModel.DataAnnotations.Schema;
using SBCommon.Logics.Business;

namespace SB.EntityFramework.Test.Logics.TypeFinders
{
    /// <summary>
    /// 
    /// </summary>
    [Table("TestTableWithNameAndSchemas", Schema = "SB")]
    public class TestTableWithNameAndSchema : Entity
    {
    }
}
