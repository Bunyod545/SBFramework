﻿using System.Collections.Generic;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITypeSynonymMigrator<T> where T : TypeSynonymInfo
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
        void Migrate(List<T> synonymInfos);
    }
}
