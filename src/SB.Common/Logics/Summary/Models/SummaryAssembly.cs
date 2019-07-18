using System.Xml.Serialization;

namespace SB.Common.Logics.Summary.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "assembly")]
    public class SummaryAssembly
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }
}
