using SB.Common.Extensions;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenLastNextTokenScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            if (token.TokenPart.Tokens.IsLast(token))
                return false;

            var nextToken = token.NextToken;
            return token.TokenPart.Tokens.IsLast(nextToken);
        }
    }
}
