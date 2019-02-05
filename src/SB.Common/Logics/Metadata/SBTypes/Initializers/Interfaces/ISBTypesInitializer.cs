using System.Collections.Generic;

namespace SBCommon.Logics.Metadata
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
