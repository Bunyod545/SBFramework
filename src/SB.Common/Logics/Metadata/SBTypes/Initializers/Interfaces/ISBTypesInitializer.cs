using System.Collections.Generic;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISBTypesInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<SBTypeInfo> GetTypeInfos();
    }
}
