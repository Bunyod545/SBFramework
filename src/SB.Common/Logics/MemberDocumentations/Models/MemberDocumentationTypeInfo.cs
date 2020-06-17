using System;
using System.Collections.Generic;

namespace SB.Common.Logics.MemberDocumentations.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberDocumentationTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<MemberDocumentationPropertyInfo> Properties { get; set; }
    }
}
