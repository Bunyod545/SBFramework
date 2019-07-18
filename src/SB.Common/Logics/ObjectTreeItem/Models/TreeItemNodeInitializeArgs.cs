using System.Reflection;

namespace SB.Common.Logics.ObjectTreeItem.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeItemNodeInitializeArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITreeItemNode ParentNode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeItemNodeInitializeArgs()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="value"></param>
        /// <param name="parentNode"></param>
        public TreeItemNodeInitializeArgs(PropertyInfo propertyInfo, object value, ITreeItemNode parentNode)
        {
            PropertyInfo = propertyInfo;
            Value = value;
            ParentNode = parentNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public TreeItemNodeInitializeArgs(object value)
        {
            Value = value;
        }
    }
}
