namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class BookTokenPartScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        public int PartNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TokenNumber { get; set; }

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
            return token != null &&
                   token.TokenPartNumber == PartNumber &&
                   token.TokenNumber == TokenNumber;
        }
    }
}
