using System.Collections.Generic;
using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.SynonymProviders.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestTypeSynonymMigrator : ITypeSynonymMigrator<TestTypeSynonymInfo>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsActual()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="synonymInfos"></param>
        public void Migrate(List<TestTypeSynonymInfo> synonymInfos)
        {
            SynonymProvider.SynonymStorage = new TestTypeSynonymStorage(synonymInfos);
        }
    }
}
