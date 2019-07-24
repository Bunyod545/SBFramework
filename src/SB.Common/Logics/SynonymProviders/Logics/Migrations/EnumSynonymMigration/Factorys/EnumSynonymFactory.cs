using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumSynonymFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<Type> _enumSynonymTypes;

        /// <summary>
        /// 
        /// </summary>
        static EnumSynonymFactory()
        {
            Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            _enumSynonymTypes = new List<Type>();

            var enumTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes().Where(w => w.IsEnum));
            enumTypes.ToList().ForEach(InternalInitialize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        private static void InternalInitialize(Type enumType)
        {
            if (enumType.IsHasAttribute<EnumSynonymAttribute>())
                _enumSynonymTypes.Add(enumType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetSynonymEnums()
        {
            return _enumSynonymTypes;
        }
    }
}
