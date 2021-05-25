using System.Collections.Generic;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextParseResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenPartInfo> TokenParts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenParts"></param>
        public TextParseResult(List<TextTokenPartInfo> tokenParts)
        {
            TokenParts = tokenParts;
        }
    }
}
