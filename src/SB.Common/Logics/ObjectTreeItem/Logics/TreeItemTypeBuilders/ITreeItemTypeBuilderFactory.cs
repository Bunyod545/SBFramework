using System;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITreeItemTypeBuilderFactory<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectTreeItemBuilder"></param>
        void Initialize(ObjectTreeItemBuilder<T> objectTreeItemBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeItemTypeBuilder"></param>
        void AddTreeItemTypeBuilder(ITreeItemTypeBuilder<T> treeItemTypeBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeItemTypeBuilder"></param>
        void RemoveTreeItemTypeBuilder(ITreeItemTypeBuilder<T> treeItemTypeBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        ITreeItemTypeBuilder<T> GetTreeItemTypeBuilder(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ITreeItemTypeBuilder<T> GetTreeItemTypeBuilder(Type type);
    }
}