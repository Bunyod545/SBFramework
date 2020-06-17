using System;
using System.Reflection;
using SB.Common.Helpers;

namespace SB.Common.Logics.MemberDocumentations
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemberDocumentationNameHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TypeExtensions = "T:";

        /// <summary>
        /// 
        /// </summary>
        public const string PropertyExtensions = "P:";

        /// <summary>
        /// 
        /// </summary>
        public const string FieldExtensions = "F:";

        /// <summary>
        /// 
        /// </summary>
        public const string EventExtensions = "E:";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetNodeName(Type type)
        {
            return TypeExtensions + type.FullName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetNodeName(PropertyInfo property)
        {
            var typeName = PropertyExtensions + property.DeclaringType?.FullName;
            return typeName + Strings.Point + property.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetNodeName(FieldInfo field)
        {
            var typeName = FieldExtensions + field.DeclaringType?.FullName;
            return typeName + Strings.Point + field.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventInfo"></param>
        /// <returns></returns>
        public static string GetNodeName(EventInfo eventInfo)
        {
            var typeName = EventExtensions + eventInfo.DeclaringType?.FullName;
            return typeName + Strings.Point + eventInfo.Name;
        }
    }
}
