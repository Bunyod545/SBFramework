using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Logics.Business;
using SB.Common.Logics.Metadata.BusinessTypes;

namespace SB.Common.Logics.Metadata
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
        public static void InitializeTypes(ISBTypesInitializer initializer)
        {
            Initializer = initializer;
            InitializeTypes();
        }

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
            if (info.ClrType.IsEnum)
            {
                AddToCache(new SBEnumType(info.TypeId, info.ClrType));
                return;
            }

            var sbTypeAttribute = info.ClrType.GetCustomAttribute<SBTypeAttribute>(true);
            var type = sbTypeAttribute?.SBType;
            if (type == null)
                type = typeof(SBType);

            var sbType = (SBType)Activator.CreateInstance(type, info.TypeId, info.ClrType);
            AddToCache(sbType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SBType> GetTypes()
        {
            return CacheList.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SBType GetType(SBObject obj)
        {
            return CacheList.ToList().FirstOrDefault(f => f.TypeId == obj?.TypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static SBType GetType<T>()
        {
            return GetType(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clrType"></param>
        /// <returns></returns>
        public static SBType GetType(Type clrType)
        {
            return CacheList.ToList().FirstOrDefault(f => f.ClrType == clrType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static SBType GetType(long typeId)
        {
            return CacheList.ToList().FirstOrDefault(f => f.TypeId == typeId);
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
            return CacheList.ToList().FirstOrDefault(f => f.ClrType == type)?.TypeId ?? -1;
        }
    }
}
