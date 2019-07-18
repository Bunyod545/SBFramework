namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectTreeItemBuilder<T> where T : ITreeItemNode, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public ITreeItemTypeBuilderFactory<T> TreeItemTypeBuilderFactory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ObjectTreeItemBuilder()
        {
            SetTreeItemTypeBuilderFactory(new TreeItemTypeBuilderFactory<T>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeItemTypeBuilderFactory"></param>
        public ObjectTreeItemBuilder<T> SetTreeItemTypeBuilderFactory(ITreeItemTypeBuilderFactory<T> treeItemTypeBuilderFactory)
        {
            TreeItemTypeBuilderFactory = treeItemTypeBuilderFactory;
            TreeItemTypeBuilderFactory.Initialize(this);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Build(object obj)
        {
            if (obj == null)
                return new T();

            var typeBuilder = TreeItemTypeBuilderFactory.GetTreeItemTypeBuilder(obj);
            return typeBuilder == null ? new T() : typeBuilder.Build(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ObjectTreeItemBuilder<T> Create()
        {
            return new ObjectTreeItemBuilder<T>();
        }
    }
}
