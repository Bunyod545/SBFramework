using System;
using System.Reflection;
using SB.Common.Logics.ObjectTreeItem.Models;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectTreeItemTypeBuilder<T> : BaseTreeItemTypeBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanBuild(object obj)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool IsCanBuild(Type type)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public override T Build(object obj)
        {
            var result = new T();
            result.Initialize(new TreeItemNodeInitializeArgs(obj));
            if (obj == null)
                return result;

            foreach (var property in obj.GetType().GetProperties())
            {
                var propValue = property.GetValue(obj);
                var builder = TreeItemTypeBuilderFactory.GetTreeItemTypeBuilder(property.PropertyType);
                builder?.BuildChild(property, propValue, result);
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
            var builder = TreeItemTypeBuilderFactory.GetTreeItemTypeBuilder(property.PropertyType);
            if (builder == null)
                return;

            var child = builder.Build(propValue);
            parent.AddChild(child);
        }
    }
}
