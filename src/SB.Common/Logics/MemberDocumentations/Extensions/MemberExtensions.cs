using System;
using System.Reflection;

namespace SB.Common.Logics.MemberDocumentations.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemberExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetMemberDocumentationName(this MemberInfo member)
        {
            if (member is PropertyInfo property)
                return MemberDocumentationNameHelper.GetNodeName(property);

            if (member is FieldInfo field)
                return MemberDocumentationNameHelper.GetNodeName(field);

            if (member is Type type)
                return MemberDocumentationNameHelper.GetNodeName(type);

            if (member is EventInfo eventInfo)
                return MemberDocumentationNameHelper.GetNodeName(eventInfo);

            return member.Name;
        }
    }
}
