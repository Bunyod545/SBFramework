using System;

namespace SB.Common.Logics.MemberDocumentations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MemberDocumentationPropertyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeName"></param>
        public MemberDocumentationPropertyAttribute(string nodeName)
        {
            NodeName = nodeName;
        }
    }
}
