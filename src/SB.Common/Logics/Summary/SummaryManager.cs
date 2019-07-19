using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SB.Common.Extensions.System;
using SB.Common.Helpers;
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
        public static Dictionary<Assembly, SummaryDocument> SummaryDocuments;

        /// <summary>
        /// 
        /// </summary>
        static SummaryManager()
        {
            SummaryDocuments = new Dictionary<Assembly, SummaryDocument>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSummary(Type type)
        {
            return GetSummary(type.Assembly, SummaryHelper.TypeExtensions + type.FullName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetSummary(PropertyInfo property)
        {
            var typeName = SummaryHelper.PropertyExtensions + property.DeclaringType?.FullName;
            var name = typeName + Strings.Point + property.Name;

            return GetSummary(property.DeclaringType?.Assembly, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetSummary(FieldInfo field)
        {
            var typeName = SummaryHelper.FieldExtensions + field.DeclaringType?.FullName;
            var name = typeName + Strings.Point + field.Name;

            return GetSummary(field.DeclaringType?.Assembly, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static string GetSummary(Assembly assembly, string memberName)
        {
            var document = GetSummaryDocument(assembly);
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
            if (assembly == null)
                return null;

            var documentPath = assembly.GetAssemblyXmlDocumentPath();
            if (!File.Exists(documentPath))
                return null;

            if (SummaryDocuments.TryGetValue(assembly, out var cacheDocument))
                return cacheDocument;

            var document = XmlDeserializer.Deserialize<SummaryDocument>(documentPath);
            SummaryDocuments.Add(assembly, document);
            return document;
        }
    }
}
