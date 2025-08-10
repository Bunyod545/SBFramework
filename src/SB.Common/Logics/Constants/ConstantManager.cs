using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<Type, List<ConstantSet>> Cache = new Dictionary<Type, List<ConstantSet>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(DbConstantContext context)
        {
            lock (Cache)
                InternalInitialize(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private static void InternalInitialize(DbConstantContext context)
        {
            if (context == null)
                return;

            if (Cache.TryGetValue(context.GetType(), out var Constants))
            {
                Constants.ForEach(f => InitFromCache(f, context));
                return;
            }

            var constantProps = GetConstantProperties(context).ToList();
            var initializedConstants = constantProps.Select(s => InitializeConstantProperty(context, s)).ToList();
            Cache.Add(context.GetType(), initializedConstants);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheConstant"></param>
        /// <param name="context"></param>
        private static void InitFromCache(ConstantSet cacheConstant, DbConstantContext context)
        {
            var constantClone = cacheConstant.Clone(context);
            constantClone.ConstantRepository = context.ConstantRepository;
            constantClone.PropertyInfo.SetValue(context, constantClone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetConstantProperties(object context)
        {
            if (context == null)
                return new List<PropertyInfo>();

            var props = context.GetType().GetProperties().ToList();
            return props.Where(IsConstantProperty).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static bool IsConstantProperty(PropertyInfo prop)
        {
            return prop != null &&
                   prop.PropertyType.IsGenericType &&
                   prop.PropertyType.GetGenericTypeDefinition() == typeof(ConstantSet<>);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static ConstantSet InitializeConstantProperty(DbConstantContext context, PropertyInfo prop)
        {
            if (context == null || prop == null)
                return null;

            var constant = (ConstantSet)Activator.CreateInstance(prop.PropertyType);
            constant.Name = prop.Name;
            constant.PropertyInfo = prop;
            constant.ValueType = prop.PropertyType.GetGenericArguments()?.FirstOrDefault();
            constant.DefaultValue = GetConstantDefaultValue(prop);
            constant.ConstantRepository = context.ConstantRepository;

            prop.SetValue(context, constant);
            return constant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static object? GetConstantDefaultValue(PropertyInfo prop)
        {
            var defValAttr = prop.GetCustomAttribute<ConstantDefaultValueAttribute>();
            if (defValAttr != null)
                return defValAttr.Value;

            return prop.GetCustomAttribute<DefaultValueAttribute>()?.Value;
        }
    }
}