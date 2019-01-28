using System.Collections.Generic;
using SB.Common.Logics.SynonymProviders.Models;

namespace SB.Common.Logics.SynonymProviders.Logics.SynonymMigration
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISynonymMigrator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsActual();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="synonymInfos"></param>
        void Migrate(List<SynonymInfo> synonymInfos);
    }
}
