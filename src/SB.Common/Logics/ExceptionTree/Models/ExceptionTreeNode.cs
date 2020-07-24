using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.ExceptionTree.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ExceptionTreeNode> Childs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public ExceptionTreeNode(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ExceptionTreeNode Clone()
        {
            var cloneNode = new ExceptionTreeNode(Key, Value);
            cloneNode.Childs = Childs?.Select(s => s.Clone()).ToList();

            return cloneNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Key}: {Value}";
        }
    }
}
