using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;
using SBCommon.Extensions;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class TableFinder
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Assembly> Assemblies { get; }

        /// <summary>
        /// 
        /// </summary>
        static TableFinder()
        {
            Assemblies = new List<Assembly>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        public static void AddAssembly(Assembly assembly)
        {
            lock (Assemblies)
                Assemblies.AddUnique(assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TypeInfo> GetTypeInfos()
        {
            return Assemblies.SelectMany(GetTypeInfos).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<TypeInfo> GetTypeInfos(Assembly assembly)
        {
            return GetContextTypes(assembly).SelectMany(GetTypeInfos).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        public static List<TypeInfo> GetTypeInfos(Type contextType)
        {
            var props = contextType.GetProperties();
            return props.Select(GetTypeInfo).ToList(w => w != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static TypeInfo GetTypeInfo(PropertyInfo property)
        {
            var propType = property.PropertyType;
            if (!propType.IsGenericType)
                return null;

            if (propType.GetGenericTypeDefinition() != typeof(DbSet<>))
                return null;

            var tableType = propType.GenericTypeArguments[0];
            var attr = tableType.GetCustomAttribute<TableAttribute>();

            var typeInfo = new TypeInfo(tableType);
            if (attr == null)
            {
                typeInfo.Schema = EFContext.DefaultSchema;
                typeInfo.Name = property.Name;
                return typeInfo;
            }

            typeInfo.Name = attr.Name;
            typeInfo.Schema = attr.Schema ?? EFContext.DefaultSchema;
            return typeInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetContextTypes()
        {
            return Assemblies.SelectMany(GetContextTypes).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetContextTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            return types.Where(w => typeof(EFContext).IsAssignableFrom(w)).ToList();
        }
    }
}
