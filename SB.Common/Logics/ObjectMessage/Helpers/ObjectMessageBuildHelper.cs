using SBCommon.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectMessageBuildHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetProperties(object obj)
        {
            if(obj == null)
                return new List<PropertyInfo>();

            if(obj is string)
                return new List<PropertyInfo>();

            if(obj.GetType().IsPrimitive)
                return new List<PropertyInfo>();

            return obj.GetType().GetProperties(BindingFlagsHelper.ObjectFields).ToList();
        }
    }
}
