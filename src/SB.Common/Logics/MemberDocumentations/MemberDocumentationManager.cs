using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using NLog;
using SB.Common.Logics.MemberDocumentations.Extensions;

namespace SB.Common.Logics.MemberDocumentations
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemberDocumentationManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<Assembly, XmlDocument> XmlDocuments;

        /// <summary>
        /// 
        /// </summary>
        static MemberDocumentationManager()
        {
            XmlDocuments = new Dictionary<Assembly, XmlDocument>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static T GetMemberDocumentation<T>(MemberInfo member) where T : class, new()
        {
            var result = new T();
            var nodes = GetElementNodes(member);
            var typeInfo = MemberDocumentationHelper.GetTypeInfo<T>();

            foreach (var xmlNode in nodes)
            {
                var prop = typeInfo.Properties.FirstOrDefault(f => f.NodeName == xmlNode.Name);
                prop?.Property?.SetValue(result, xmlNode.InnerText);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static List<XmlNode> GetElementNodes(MemberInfo member)
        {
            var document = GetXmlDocument(member.DeclaringType.Assembly);
            if (document == null)
                return new List<XmlNode>();

            var element = member.GetMemberDocumentationName();
            var membersNode = document.LastChild?.LastChild;

            var nodes = membersNode?.ChildNodes.OfType<XmlNode>().ToList();
            var childNodes = nodes?.FirstOrDefault(f => f.Attributes["name"]?.Value == element)?.ChildNodes;

            return childNodes?.OfType<XmlNode>().ToList() ?? new List<XmlNode>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static XmlDocument GetXmlDocument(Assembly assembly)
        {
            Logger.Info("Get xml document begin for assembly: " + assembly);
            if (assembly == null)
                return null;

            Logger.Info("Check cached document for assembly: " + assembly);
            if (XmlDocuments.TryGetValue(assembly, out var cacheDocument))
            {
                Logger.Info("Find cached document for assembly: " + assembly);
                return cacheDocument;
            }

            var documentPath = assembly.GetAssemblyXmlDocumentPath();
            Logger.Info("Get xml document begin from path: " + documentPath);

            if (!File.Exists(documentPath))
            {
                Logger.Info("Xml document not exists on path: " + documentPath);
                return null;
            }

            var document = new XmlDocument();
            document.LoadXml(File.ReadAllText(documentPath));

            XmlDocuments.Add(assembly, document);
            Logger.Info("Read xml document finished for assembly: " + assembly);
            return document;
        }
    }
}
