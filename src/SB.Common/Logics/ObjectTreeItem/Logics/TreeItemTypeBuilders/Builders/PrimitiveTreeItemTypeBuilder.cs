using System;
using System.Reflection;
using SB.Common.Logics.ObjectTreeItem.Models;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class PrimitiveTreeItemTypeBuilder<T> : BaseTreeItemTypeBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanBuild(object obj)
        {
            if (obj == null)
                return false;

            return obj.GetType().IsPrimitive || obj is string;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool IsCanBuild(Type type)
        {
            return type.IsPrimitive || type == typeof(string);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public override T Build(object obj)
        {
            var result = new T();
            result.Initialize(new TreeItemNodeInitializeArgs(obj));

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
            var result = new T();
            result.Initialize(new TreeItemNodeInitializeArgs(property, propValue, parent));

            parent.AddChild(result);
        }
    }
}