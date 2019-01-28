using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.SynonymProviders.Logics.SynonymMigration
{
    /// <summary>
    /// 
    /// </summary>
    public static class SynonymMigrationFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Type> SynonymTypes { get; }

        /// <summary>
        /// 
        /// </summary>
        static SynonymMigrationFactory()
        {
            SynonymTypes = new List<Type>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Register<T>()
        {
            var synonym = SynonymTypes.FirstOrDefault(f => f == typeof(T));
            if (synonym == null)
                SynonymTypes.Add(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        public static void UnRegister<T>()
        {
            var synonym = SynonymTypes.FirstOrDefault(f => f == typeof(T));
            if (synonym != null)
                SynonymTypes.Remove(typeof(T));
        }
    }
}
