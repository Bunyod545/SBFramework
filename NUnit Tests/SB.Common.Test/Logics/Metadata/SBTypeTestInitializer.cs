using System;
using System.Collections.Generic;
using System.Text;
using SB.Common.Test.Logics.Metadata.Tables;
using SBCommon.Logics.Metadata;

namespace SB.Common.Test.Logics.Metadata
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
        }
    }
}
