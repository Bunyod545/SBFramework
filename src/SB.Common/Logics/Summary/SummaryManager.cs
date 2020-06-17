using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using SB.Common.Logics.MemberDocumentations;
using SB.Common.Logics.MemberDocumentations.Extensions;
using SB.Common.Logics.Summary.Helpers;
using SB.Common.Logics.Summary.Models;

namespace SB.Common.Logics.Summary
{
    /// <summary>
    /// 
    /// </summary>
    public static class SummaryManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSummary(Type type)
        {
            return GetSummary(type.Assembly, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetSummary(PropertyInfo property)
        {
            return GetSummary(property.DeclaringType?.Assembly, property);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetSummary(FieldInfo field)
        {
            return GetSummary(field.DeclaringType?.Assembly, field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetSummary(Assembly assembly, MemberInfo member)
        {
            var document = GetSummaryDocument(assembly);
            var memberName = member.GetMemberDocumentationName();
            var summary = document?.Members?.MemberList.FirstOrDefault(f => f.Name == memberName)?.Summary;
            if (summary == null)
                return null;

            var whiteSpaceLenght = SummaryHelper.SummaryWhiteSpace.Length;
            if (summary.StartsWith(SummaryHelper.SummaryWhiteSpace))
                summary = summary.Substring(whiteSpaceLenght, summary.Length - whiteSpaceLenght);

            if (summary.EndsWith(SummaryHelper.SummaryWhiteSpace))
                summary = summary.Substring(0, summary.Length - whiteSpaceLenght);

            return summary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static SummaryDocument GetSummaryDocument(Assembly assembly)
        {
            var summaryXmlDocument = MemberDocumentationManager.GetXmlDocument(assembly);
            if (summaryXmlDocument == null)
                return null;

            var memoryStream = new MemoryStream();
            summaryXmlDocument.Save(memoryStream);
            memoryStream.Position = 0;

            var serializer = new XmlSerializer(typeof(SummaryDocument));
            return (SummaryDocument)serializer.Deserialize(memoryStream);
        }
    }
}
