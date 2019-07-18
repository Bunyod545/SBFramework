using System.Xml.Serialization;

namespace SB.Common.Logics.Summary.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "doc")]
    public class SummaryDocument
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "assembly")]
        public SummaryAssembly Assembly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "members")]
        public SummaryMembers Members { get; set; }
    }
}
