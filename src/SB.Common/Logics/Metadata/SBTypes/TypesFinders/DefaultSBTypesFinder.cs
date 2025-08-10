using SB.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.Metadata.SBTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultSBTypesFinder : ISBTypesFinder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<SBTypeInfo> Find()
        {
            var result = FindPrimitiveTypes();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(FindDbTypes).ToList();

            result.AddRange(types);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<SBTypeInfo> FindPrimitiveTypes()
        {
            return new List<SBTypeInfo>()
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(bool), SBPrimitiveTypes.Boolean))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(short), SBPrimitiveTypes.Short))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(int), SBPrimitiveTypes.Integer))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(long), SBPrimitiveTypes.Long))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(float), SBPrimitiveTypes.Float))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(double), SBPrimitiveTypes.Double))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(decimal), SBPrimitiveTypes.Decimal))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(string), SBPrimitiveTypes.String))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(Guid), SBPrimitiveTypes.Guid))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(byte[]), SBPrimitiveTypes.ByteArray))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(DateTime), SBPrimitiveTypes.DateTime))
                .AddItem(SBTypeInfo.CreatePrimitiveType(typeof(TimeSpan), SBPrimitiveTypes.TimeSpan));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private List<SBTypeInfo> FindDbTypes(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(w =>
                   !w.IsAbstract &&
                    w.IsDefined(typeof(SBTypeAttribute), true)
                ).ToList();
            return types.Select(ConvertToDbType).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private SBTypeInfo ConvertToDbType(Type type)
        {
            var table = type.GetCustomAttribute<SBTypeAttribute>();
            var result = new SBTypeInfo(0, type);
            result.Name = type.Name;

            return result;
        }
    }
}
