using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeItemTypeBuilderFactory<T> : ITreeItemTypeBuilderFactory<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        private List<ITreeItemTypeBuilder<T>> _treeItemTypeBuilder;

        /// <summary>
        /// 
        /// </summary>
        public TreeItemTypeBuilderFactory()
        {
            InitializeStandartBuilders();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void InitializeStandartBuilders()
        {
            _treeItemTypeBuilder = new List<ITreeItemTypeBuilder<T>>();
            _treeItemTypeBuilder.Add(new PrimitiveTreeItemTypeBuilder<T>());
            _treeItemTypeBuilder.Add(new ModuleTreeItemTypeBuilder<T>());
            _treeItemTypeBuilder.Add(new DictionaryTreeItemTypeBuilder<T>());
            _treeItemTypeBuilder.Add(new EnumerableTreeItemTypeBuilder<T>());
            _treeItemTypeBuilder.Add(new ObjectTreeItemTypeBuilder<T>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectTreeItemBuilder"></param>
        public void Initialize(ObjectTreeItemBuilder<T> objectTreeItemBuilder)
        {
            _treeItemTypeBuilder?.ForEach(f=>f.Initialize(objectTreeItemBuilder));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeItemTypeBuilder"></param>
        public void AddTreeItemTypeBuilder(ITreeItemTypeBuilder<T> treeItemTypeBuilder)
        {
            _treeItemTypeBuilder.Add(treeItemTypeBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeItemTypeBuilder"></param>
        public void RemoveTreeItemTypeBuilder(ITreeItemTypeBuilder<T> treeItemTypeBuilder)
        {
            _treeItemTypeBuilder.Remove(treeItemTypeBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ITreeItemTypeBuilder<T> GetTreeItemTypeBuilder(object obj)
        {
            return _treeItemTypeBuilder.FirstOrDefault(f => f.IsCanBuild(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ITreeItemTypeBuilder<T> GetTreeItemTypeBuilder(Type type)
        {
            return _treeItemTypeBuilder.FirstOrDefault(f => f.IsCanBuild(type));
        }
    }
}
