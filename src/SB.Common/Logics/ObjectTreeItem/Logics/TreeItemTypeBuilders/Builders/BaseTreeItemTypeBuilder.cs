using System;
using System.Reflection;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseTreeItemTypeBuilder<T>: ITreeItemTypeBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        protected ObjectTreeItemBuilder<T> ObjectTreeItemBuilder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected ITreeItemTypeBuilderFactory<T> TreeItemTypeBuilderFactory => ObjectTreeItemBuilder?.TreeItemTypeBuilderFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectTreeItemBuilder"></param>
        public virtual void Initialize(ObjectTreeItemBuilder<T> objectTreeItemBuilder)
        {
            ObjectTreeItemBuilder = objectTreeItemBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool IsCanBuild(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract bool IsCanBuild(Type type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract T Build(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propValue"></param>
        /// <param name="parent"></param>
        public abstract void BuildChild(PropertyInfo property, object propValue, ITreeItemNode parent);
    }
}
