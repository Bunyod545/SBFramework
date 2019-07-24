using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using SB.Common.Helpers;
using SB.Common.Logics.Summary;
using SB.Common.Logics.Summary.Helpers;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumSynonymMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, PropertyInfo> _propertyInfos;

        /// <summary>
        /// 
        /// </summary>
        public EnumSynonymMigrateManager()
        {
            _propertyInfos = new Dictionary<string, PropertyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMigrator"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        public void Migrate<TMigrator, TModel>() where TModel : EnumSynonymInfo, new() where TMigrator : IEnumSynonymMigrator<TModel>, new()
        {
            var migrator = new TMigrator();
            if (migrator.IsActual())
                return;

            InitializeProperties<TModel>();
            var infos = GetEnumSynonymInfos<TModel>();
            migrator.Migrate(infos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        private void InitializeProperties<TModel>()
        {
            var modelType = typeof(TModel);
            modelType.GetProperties().ToList().ForEach(InitializeProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        private void InitializeProperty(PropertyInfo property)
        {
            var attr = property.GetCustomAttribute<EnumSynonymPropertyAttribute>();
            if (attr == null)
                return;

            if (!_propertyInfos.ContainsKey(attr.Name))
                _propertyInfos.Add(attr.Name, property);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        private List<TModel> GetEnumSynonymInfos<TModel>() where TModel : EnumSynonymInfo, new()
        {
            var result = new List<TModel>();
            var enumTypes = EnumSynonymFactory.GetSynonymEnums();
            enumTypes.ForEach(f => result.AddRange(GetEnumTypeSynonymInfos<TModel>(f)));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private IEnumerable<TModel> GetEnumTypeSynonymInfos<TModel>(Type enumType) where TModel : EnumSynonymInfo, new()
        {
            var names = Enum.GetNames(enumType);
            return names.Select(enumType.GetField).Select(GetSynonymInfo<TModel>);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        private TModel GetSynonymInfo<TModel>(FieldInfo field) where TModel : EnumSynonymInfo, new()
        {
            var info = new TModel();
            info.Key = field.DeclaringType.Name + Strings.Point + field.Name;

            var synonymsNodes = GetSynonymElement(field);
            foreach (var node in synonymsNodes)
            {
                var prop = _propertyInfos.FirstOrDefault(f => f.Key == node.Name);
                prop.Value?.SetValue(info, node.InnerText);
            }

            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private IEnumerable<XmlNode> GetSynonymElement(FieldInfo field)
        {
            var document = SummaryManager.GetSummaryXmlDocument(field.DeclaringType.Assembly);
            if (document == null)
                return null;

            var element = SummaryHelper.FieldExtensions + field.DeclaringType.FullName + Strings.Point + field.Name;
            var membersNode = document.LastChild?.LastChild;

            var nodes = membersNode?.ChildNodes.OfType<XmlNode>().ToList();
            return nodes?.FirstOrDefault(f => f.Attributes["name"]?.Value == element)?.ChildNodes.OfType<XmlNode>();
        }
    }
}
