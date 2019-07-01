using System;
using System.Collections.Generic;
using System.Reflection;
using SB.Common.Helpers;
using SB.Migrator.Logics.Database;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresColumnTypeMappingSource : IColumnTypeMappingSource
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Type, string> _typeMapping;

        /// <summary>
        /// 
        /// </summary>
        public PostgresColumnTypeMappingSource()
        {
            _typeMapping = new Dictionary<Type, string>();
            _typeMapping.Add(typeof(bool), "boolean");
            _typeMapping.Add(typeof(int), "integer");
            _typeMapping.Add(typeof(long), "bigint");
            _typeMapping.Add(typeof(short), "smallint");
            _typeMapping.Add(typeof(DateTime), "date");
            _typeMapping.Add(typeof(decimal), "money");
            _typeMapping.Add(typeof(float), "real");
            _typeMapping.Add(typeof(string), "text");
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
            var originalType = TypesHelper.GetOriginalType(systemType);
            if (originalType.IsEnum)
                originalType = typeof(int);

            return _typeMapping.TryGetValue(originalType, out var storeType) ? storeType : null;
        }
    }
}
