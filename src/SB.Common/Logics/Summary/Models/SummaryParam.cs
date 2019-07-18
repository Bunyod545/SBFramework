using System.Xml.Serialization;

namespace SB.Common.Logics.Summary.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "param")]
    public class SummaryParam
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
