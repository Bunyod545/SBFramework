using System;
using System.Linq;
using System.Reflection;
using SBCommon.Logics.Business;

namespace SBCommon.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SBType
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISBTypesInitializer Initializer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static void InitializeTypes()
        {
            if (Initializer == null)
                throw new ArgumentNullException(nameof(Initializer));

            CacheList.Clear();
            var types = Initializer.GetTypeInfos().ToList();
            types.ForEach(InitializeType);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void InitializeType(SBTypeInfo info)
        {
            var sbTypeAttribute = info.ClrType.GetCustomAttribute<SBTypeAttribute>(true);
            if (sbTypeAttribute == null)
                throw new InvalidOperationException($"Type {info.ClrType} not marked with SBTypeAttribute!");

            var type = sbTypeAttribute.SBType;
            var sbType = (SBType)Activator.CreateInstance(type, info.TypeId, info.ClrType);
            AddToCache(sbType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SBType GetType(SBObject obj)
        {
            return CacheList.FirstOrDefault(f => f.TypeId == obj?.TypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static SBType GetType(long typeId)
        {
            return CacheList.FirstOrDefault(f => f.TypeId == typeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long GetTypeId(object obj)
        {
            return GetTypeId(obj?.GetType());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static long GetTypeId(Type type)
        {
            return CacheList.FirstOrDefault(f => f.ClrType == type)?.TypeId ?? -1;
        }
    }
}
