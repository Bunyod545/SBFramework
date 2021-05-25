namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenTypeScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            return InternalIsAllRight(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        protected bool InternalIsAllRight(TextTokenInfo token)
        {
            if (token == null)
                return false;

            return token.TokenType == TokenType;
        }
    }
}