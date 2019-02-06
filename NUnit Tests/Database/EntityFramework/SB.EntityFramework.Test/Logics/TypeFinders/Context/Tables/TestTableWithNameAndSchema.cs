using System.ComponentModel.DataAnnotations.Schema;
using SBCommon.Logics.Business;

namespace SB.EntityFramework.Test.Logics.TypeFinders
{
    /// <summary>
    /// 
    /// </summary>
    [Table(TableName, Schema = Schema)]
    public class TestTableWithNameAndSchema : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TableName = "TestTableWithNameAndSchemas";

        /// <summary>
        /// 
        /// </summary>
        public const string Schema = "SB";
    }
}
