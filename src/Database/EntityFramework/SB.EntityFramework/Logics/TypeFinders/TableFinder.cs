using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;
using SB.Common.Extensions;

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
        public static List<Assembly> SafeAssemblies => Assemblies.Any() ? 
                Assemblies : 
                AppDomain.CurrentDomain.GetAssemblies().ToList();

        /// <summary>
        /// 
        /// </summary>
        public static List<TypeInfo> CacheTypeInfos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static TableFinder()
        {
            Assemblies = new List<Assembly>();
            CacheTypeInfos = new List<TypeInfo>();
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
        /// <typeparam name="T"></typeparam>
        public static void RemoveTable<T>()
        {
            CacheTypeInfos.RemoveAll(r => r.ClrType == typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TypeInfo> InitalizeTypeInfos()
        {
            if (CacheTypeInfos != null && CacheTypeInfos.Any())
                return CacheTypeInfos;

            return SafeAssemblies.SelectMany(InitalizeTypeInfos).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<TypeInfo> InitalizeTypeInfos(Assembly assembly)
        {
            return GetContextTypes(assembly).SelectMany(InitalizeTypeInfos).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        public static List<TypeInfo> InitalizeTypeInfos(Type contextType)
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
            var tableType = GetTableType(property);
            if (tableType == null || tableType == typeof(SbType))
                return null;

            var attr = tableType.GetCustomAttribute<TableAttribute>();
            var typeInfo = new TypeInfo(tableType);

            typeInfo.Name = attr?.Name ?? property.Name;
            typeInfo.Schema = attr?.Schema ?? EFContext.DefaultSchema;

            CacheTypeInfos.Add(typeInfo);
            return typeInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static Type GetTableType(PropertyInfo property)
        {
            var propType = property.PropertyType;
            if (!propType.IsGenericType)
                return null;

            if (propType.GetGenericTypeDefinition() != typeof(DbSet<>))
                return null;

            return propType.GenericTypeArguments[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetContextTypes()
        {
            var types = SafeAssemblies.SelectMany(s=>s.GetTypes());
            return types.Where(w => typeof(EFContext).IsAssignableFrom(w)).ToList();
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
