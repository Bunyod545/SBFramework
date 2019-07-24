using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.EnumSynonyms.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestEnumSynonymInfo : EnumSynonymInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumSynonymProperty("uz")]
        public string Uz { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [EnumSynonymProperty("ru")]
        public string Ru { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [EnumSynonymProperty("en")]
        public string En { get; set; }
    }
}
