using System;
using System.Reflection;

namespace SB.Migrator.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public interface IColumnTypeMappingSource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemType"></param>
        /// <returns></returns>
        string FindType(Type systemType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        string FindType(PropertyInfo propertyInfo);
    }
}
