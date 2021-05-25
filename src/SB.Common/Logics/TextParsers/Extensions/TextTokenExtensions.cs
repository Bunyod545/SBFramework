using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TextTokenExtensions
    {
        // <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IEnumerable<TextTokenInfo> GetNextTokens(this TextTokenInfo token)
        {
            var nextToken = token.NextToken;
            while (nextToken != null)
            {
                var existsNextToken = nextToken;
                nextToken = existsNextToken.NextToken;

                yield return existsNextToken;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IEnumerable<TextTokenInfo> GetPreviousTokens(this TextTokenInfo token)
        {
            var previous = token.PreviousToken;
            while (previous != null)
            {
                var existsPreviousToken = previous;
                previous = existsPreviousToken.PreviousToken;

                yield return existsPreviousToken;
            }
        }
    }
}
