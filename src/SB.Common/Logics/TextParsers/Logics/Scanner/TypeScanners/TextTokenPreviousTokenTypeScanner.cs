namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenPreviousTokenTypeScanner : TextTokenTypeScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            if (token == null)
                return false;

            return token.PreviousToken?.TokenType == TokenType;
        }
    }
}
