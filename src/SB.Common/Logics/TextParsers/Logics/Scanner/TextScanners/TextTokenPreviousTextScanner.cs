using System.Linq;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenPreviousTextScanner : TextTokenTextScanner
    {
        /// <summary>
        /// 
        /// </summary>
        public int PreviousCount { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            var tokens = token.GetPreviousTokens().ToList();
            if (tokens.Count < PreviousCount)
                return false;

            return InternalIsAllRight(tokens[PreviousCount - 1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousCount"></param>
        public void WithPreviousCount(int previousCount)
        {
            PreviousCount = previousCount;
        }
    }
}
