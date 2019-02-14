using System;
using System.Collections.Generic;
using System.Reflection;
using SB.Migrator.Logics.Database;

namespace SB.Migrator.SqlServer.Logics.ColumnTypeMappingSource
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlColumnTypeMappingSource : IColumnTypeMappingSource
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Type, string> TypeMapping;

        /// <summary>
        /// 
        /// </summary>
        public SqlColumnTypeMappingSource()
        {
            TypeMapping = new Dictionary<Type, string>();
            TypeMapping.Add(typeof(bool), "bit");
            TypeMapping.Add(typeof(int), "int");
            TypeMapping.Add(typeof(long), "bigint");
            TypeMapping.Add(typeof(short), "smallint");
            TypeMapping.Add(typeof(DateTime), "datetime");
            TypeMapping.Add(typeof(decimal), "decimal(18, 2)");
            TypeMapping.Add(typeof(float), "float");
            TypeMapping.Add(typeof(string), "nvarchar(max)");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public string FindType(PropertyInfo propertyInfo)
        {
            return FindType(propertyInfo.PropertyType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemType"></param>
        /// <returns></returns>
        public string FindType(Type systemType)
        {
            return TypeMapping.TryGetValue(systemType, out var storeType) ? storeType : null;
        }
    }
}
