using System;
using System.Collections.Generic;
using System.Reflection;
using SB.Common.Helpers;
using SB.Migrator.Logics.Database;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlColumnTypeMappingSource : IColumnTypeMappingSource
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Type, string> _typeMapping;

        /// <summary>
        /// 
        /// </summary>
        public MySqlColumnTypeMappingSource()
        {
            _typeMapping = new Dictionary<Type, string>();
            _typeMapping.Add(typeof(bool), "boolean");
            _typeMapping.Add(typeof(int), "integer");
            _typeMapping.Add(typeof(long), "bigint");
            _typeMapping.Add(typeof(short), "smallint");
            _typeMapping.Add(typeof(DateTime), "date");
            _typeMapping.Add(typeof(decimal), "decimal");
            _typeMapping.Add(typeof(float), "float");
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
