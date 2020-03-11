using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.SynonymProviders.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestTypeSynonymInfo : TypeSynonymInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [TypeSynonymProperty("uz")]
        public string Uz { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [TypeSynonymProperty("ru")]
        public string Ru { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [TypeSynonymProperty("en")]
        public string En { get; set; }
    }
}
