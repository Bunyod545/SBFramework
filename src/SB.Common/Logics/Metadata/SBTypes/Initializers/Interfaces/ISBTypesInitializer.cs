using SB.Common.Logics.Metadata.SBTypes;
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
        List<SBTypeInfo> GetTypeInfos();
    }
}
