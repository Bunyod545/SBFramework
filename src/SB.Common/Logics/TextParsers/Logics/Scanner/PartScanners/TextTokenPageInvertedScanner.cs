using System.Linq;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenPageInvertedScanner : TextTokenScanner
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
            if (token == null)
                return false;

            if (token.TokenPartNumber != PartNumber)
                return false;

            if (token.TokenPart.TokensCount < TokenNumber)
                return false;

            var tokens = token.TokenPart.Tokens.ToList();
            tokens.Reverse();

            var tokenNumber = tokens[TokenNumber - 1].TokenNumber;
            return tokenNumber == token.TokenNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public TextTokenPageInvertedScanner WithPartNumber(int partNumber)
        {
            PartNumber = partNumber;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenNumber"></param>
        /// <returns></returns>
        public TextTokenPageInvertedScanner WithTokenNumber(int tokenNumber)
        {
            TokenNumber = tokenNumber;
            return this;
        }
    }
}
