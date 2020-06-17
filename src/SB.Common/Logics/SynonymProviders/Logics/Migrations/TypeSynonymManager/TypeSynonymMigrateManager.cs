using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Helpers;
using SB.Common.Logics.MemberDocumentations;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeSynonymMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, PropertyInfo> _propertyInfos;

        /// <summary>
        /// 
        /// </summary>
        public TypeSynonymMigrateManager()
        {
            _propertyInfos = new Dictionary<string, PropertyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMigrator"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        public void Migrate<TMigrator, TModel>() where TModel : TypeSynonymInfo, new() where TMigrator : ITypeSynonymMigrator<TModel>, new()
        {
            var migrator = new TMigrator();
            if (migrator.IsActual())
                return;

            InitializeProperties<TModel>();
            var infos = GetTypeSynonymInfos<TModel>();
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
            var attr = property.GetCustomAttribute<TypeSynonymPropertyAttribute>();
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
        private List<TModel> GetTypeSynonymInfos<TModel>() where TModel : TypeSynonymInfo, new()
        {
            return TypeSynonymFactory
                .GetSynonymTypes()
                .SelectMany(GetTypeSynonymInfos<TModel>).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        private IEnumerable<TModel> GetTypeSynonymInfos<TModel>(Type type) where TModel : TypeSynonymInfo, new()
        {
            var props = type.GetProperties();
            return props.Select(GetSynonymInfo<TModel>);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        private TModel GetSynonymInfo<TModel>(PropertyInfo property) where TModel : TypeSynonymInfo, new()
        {
            var info = new TModel();
            info.Key = property.DeclaringType.Name + Strings.Point + property.Name;

            var synonymsNodes = MemberDocumentationManager.GetElementNodes(property);
            foreach (var node in synonymsNodes)
            {
                var prop = _propertyInfos.FirstOrDefault(f => f.Key == node.Name);
                prop.Value?.SetValue(info, node.InnerText);
            }

            return info;
        }
    }
}
