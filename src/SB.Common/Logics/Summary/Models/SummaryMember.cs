using System.Xml.Serialization;

namespace SB.Common.Logics.Summary.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SummaryMember
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "param")]
        public SummaryParam Param { get; set; }
    }
}
