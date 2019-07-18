using System.Collections.Generic;
using SB.Common.Extensions;
using SB.Common.Logics.ObjectTreeItem.Models;

namespace SB.Common.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTreeItemNode : ITreeItemNode
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ExceptionTreeItemNode> Childrens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExceptionTreeItemNode()
        {
            Childrens = new List<ExceptionTreeItemNode>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Initialize(TreeItemNodeInitializeArgs args)
        {
            Key = args.PropertyInfo?.Name ?? args.Value?.GetType().ToSafeString();
            Value = args.Value.ToSafeString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void AddChild(ITreeItemNode node)
        {
            Childrens.Add((ExceptionTreeItemNode)node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Key: {Key}, Value: {Value}";
        }
    }
}
