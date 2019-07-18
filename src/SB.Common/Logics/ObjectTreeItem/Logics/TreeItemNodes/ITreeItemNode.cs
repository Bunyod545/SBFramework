using SB.Common.Logics.ObjectTreeItem.Models;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITreeItemNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        void Initialize(TreeItemNodeInitializeArgs args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        void AddChild(ITreeItemNode node);
    }
}
