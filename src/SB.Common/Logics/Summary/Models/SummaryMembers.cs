using System.Collections.Generic;
using System.Xml.Serialization;

namespace SB.Common.Logics.Summary.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "members")]
    public class SummaryMembers
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "member")]
        public List<SummaryMember> MemberList { get; set; }
    }
}
