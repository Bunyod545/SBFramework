using System.ComponentModel.DataAnnotations.Schema;
using SB.Common.Logics.Business;

namespace SB.EntityFramework.Test.Logics.TypeFinders
{
    /// <summary>
    /// 
    /// </summary>
    [Table(TableName)]
    public class TestTableWithName : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TableName = "TestTableWithNames";
    }
}
