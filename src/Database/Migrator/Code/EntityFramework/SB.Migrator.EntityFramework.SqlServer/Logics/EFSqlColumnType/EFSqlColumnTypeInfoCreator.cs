using Microsoft.EntityFrameworkCore.Metadata;

namespace SB.Migrator.EntityFramework.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class EFSqlColumnTypeInfoCreator : IEFColumnTypeInfoCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public EFColumnTypeInfo Create(IProperty property) => new EFColumnTypeInfo(property);
    }
}
