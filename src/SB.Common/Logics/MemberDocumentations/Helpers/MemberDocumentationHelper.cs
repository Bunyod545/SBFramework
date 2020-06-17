using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Logics.MemberDocumentations.Attributes;
using SB.Common.Logics.MemberDocumentations.Models;

namespace SB.Common.Logics.MemberDocumentations
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemberDocumentationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MemberDocumentationTypeInfo GetTypeInfo<T>()
        {
            var type = typeof(T);

            var info = new MemberDocumentationTypeInfo();
            info.Type = type;
            info.Properties = GetTypeProperties(type);

            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<MemberDocumentationPropertyInfo> GetTypeProperties(Type type)
        {
            var properties = type.GetProperties().Where(w => w.IsHasAttribute<MemberDocumentationPropertyAttribute>());
            return properties.Select(GetPropertyInfo).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static MemberDocumentationPropertyInfo GetPropertyInfo(PropertyInfo property)
        {
            var info = new MemberDocumentationPropertyInfo();
            info.Property = property;
            info.NodeName = property.GetCustomAttribute<MemberDocumentationPropertyAttribute>()?.NodeName;

            return info;
        }
    }
}
