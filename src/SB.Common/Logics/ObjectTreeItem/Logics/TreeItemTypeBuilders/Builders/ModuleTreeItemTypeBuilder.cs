using System;
using System.Collections;
using System.Reflection;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class ModuleTreeItemTypeBuilder<T>: BaseTreeItemTypeBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanBuild(object obj)
        {
            return obj is Module;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool IsCanBuild(Type type)
        {
            return type == typeof(Module) || type.IsSubclassOf(typeof(Module));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public override T Build(object obj)
        {
            return new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propValue"></param>
        /// <param name="parent"></param>
        public override void BuildChild(PropertyInfo property, object propValue, ITreeItemNode parent)
        {
        }
    }
}