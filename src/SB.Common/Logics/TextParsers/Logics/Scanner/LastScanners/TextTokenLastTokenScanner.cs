using SB.Common.Extensions;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenLastTokenScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            return token.TokenPart.Tokens.IsLast(token);
        }
    }
}
