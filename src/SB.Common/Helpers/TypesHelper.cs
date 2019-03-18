using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypesHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetOriginalType(Type type)
        {
            if (!type.IsGenericType)
                return type;

            if (type.IsNullable())
                return type.GetGenericArguments().FirstOrDefault();

            return type;
        }
    }
}
