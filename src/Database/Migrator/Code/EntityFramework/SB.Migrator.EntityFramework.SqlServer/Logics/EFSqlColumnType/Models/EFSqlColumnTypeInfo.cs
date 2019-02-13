using Microsoft.EntityFrameworkCore.Metadata;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFSqlColumnTypeInfo : EFColumnTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        public EFSqlColumnTypeInfo(IProperty property) : base(property)
        {
        }
    }
}
