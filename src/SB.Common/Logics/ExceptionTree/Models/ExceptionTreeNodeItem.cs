namespace SB.Common.Logics.ExceptionTree.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTreeNodeItem : ExceptionTreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        public object TreeItemObject { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeItemObject"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public ExceptionTreeNodeItem(object treeItemObject, string key, string value) : base(key, value)
        {
            TreeItemObject = treeItemObject;
        }
    }
}
