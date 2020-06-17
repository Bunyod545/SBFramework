using SB.Common.Logics.MemberDocumentations.Attributes;

namespace SB.Common.Test.Logics.MemberDocumentations.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TestMemberDocumentationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [MemberDocumentationProperty("test")]
        public string Test { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MemberDocumentationProperty("test2")]
        public string Test2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MemberDocumentationProperty("test3")]
        public string Test3 { get; set; }
    }
}
