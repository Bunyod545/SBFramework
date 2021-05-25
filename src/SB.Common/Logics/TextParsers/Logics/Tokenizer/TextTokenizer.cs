using System.Collections.Generic;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TextTokenizer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textParts"></param>
        /// <returns></returns>
        public abstract List<TextTokenPartInfo> GetTokens(List<TextPartInfo> textParts); 
    }
}
