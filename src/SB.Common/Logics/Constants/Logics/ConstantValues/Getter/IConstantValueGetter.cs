using System.Collections.Generic;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConstantValueGetter
    {
        /// <summary>
        /// 
        /// </summary>
        ConstantSet Constant { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T GetConstantValue<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ConstantValueInfo<T>> GetConstantValues<T>();
    }
}