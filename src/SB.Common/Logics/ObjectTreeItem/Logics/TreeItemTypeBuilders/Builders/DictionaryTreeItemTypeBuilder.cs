using System;
using System.Collections;
using System.Reflection;
using SB.Common.Logics.ObjectTreeItem.Models;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class DictionaryTreeItemTypeBuilder<T>: BaseTreeItemTypeBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanBuild(object obj)
        {
            return obj is IDictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool IsCanBuild(Type type)
        {
            return type == typeof(IDictionary) || type.IsHasInterface<IDictionary>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public override T Build(object obj)
        {
            if (!(obj is IDictionary dictionary))
                return new T();

            var result = new T();
            result.Initialize(new TreeItemNodeInitializeArgs(dictionary));

            foreach (var item in dictionary)
            {
                var builder = TreeItemTypeBuilderFactory.GetTreeItemTypeBuilder(item);
                if (builder == null)
                    continue;

                var child = builder.Build(item);
                result.AddChild(child);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propValue"></param>
        /// <param name="parent"></param>
        public override void BuildChild(PropertyInfo property, object propValue, ITreeItemNode parent)
        {
            if (!(propValue is IDictionary dictionary))
                return;

            var result = new T();
            result.Initialize(new TreeItemNodeInitializeArgs(dictionary));

            foreach (var item in dictionary)
            {
                var builder = TreeItemTypeBuilderFactory.GetTreeItemTypeBuilder(item);
                if (builder == null)
                    continue;

                var child = builder.Build(item);
                result.AddChild(child);
            }

            parent?.AddChild(result);
        }
    }
}