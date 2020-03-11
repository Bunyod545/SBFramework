using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeSynonymFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<Type> _typeSynonymTypes;

        /// <summary>
        /// 
        /// </summary>
        static TypeSynonymFactory()
        {
            Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            _typeSynonymTypes = new List<Type>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(s => s.GetTypes().Where(w => w.IsClass || w.IsValueType));
            types.ToList().ForEach(InternalInitialize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        private static void InternalInitialize(Type enumType)
        {
            if (enumType.IsHasAttribute<TypeSynonymAttribute>())
                _typeSynonymTypes.Add(enumType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetSynonymTypes()
        {
            return _typeSynonymTypes;
        }
    }
}
