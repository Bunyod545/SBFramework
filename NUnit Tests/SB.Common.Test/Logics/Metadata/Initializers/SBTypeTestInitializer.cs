using System.Collections.Generic;
using SB.Common.Test.Logics.Metadata.Tables;
using SBCommon.Logics.Metadata;

namespace SB.Common.Test.Logics.Metadata.Initializers
{
    /// <summary>
    /// 
    /// </summary>
    public class SBTypeTestInitializer : ISBTypesInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SBTypeInfo> GetTypeInfos()
        {
            yield return new SBTypeInfo(1, typeof(CountryTestEntity));
            yield return new SBTypeInfo(2, typeof(CityTestEntity));
            yield return new SBTypeInfo(3, typeof(TabTestDetail));
            yield return new SBTypeInfo(4, typeof(MovementDocument));
        }
    }
}
