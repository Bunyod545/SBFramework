using Microsoft.EntityFrameworkCore.Metadata;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEFColumnTypeInfoCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        EFColumnTypeInfo Create(IProperty property);
    }
}
