using System;
using System.Reflection;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITreeItemTypeBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        void Initialize(ObjectTreeItemBuilder<T> objectTreeItemBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsCanBuild(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsCanBuild(Type type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        T Build(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propValue"></param>
        /// <param name="parent"></param>
        void BuildChild(PropertyInfo property, object propValue, ITreeItemNode parent);
    }
}
