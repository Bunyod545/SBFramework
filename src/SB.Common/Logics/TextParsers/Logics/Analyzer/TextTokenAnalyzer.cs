using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenAnalyzer
    {
        /// <summary>
        /// 
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenScanner> Scanners { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenType"></param>
        public TextTokenAnalyzer(string tokenType)
        {
            TokenType = tokenType;
            Scanners = new List<TextTokenScanner>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual string Analyze(TextTokenInfo token)
        {
            if (!string.IsNullOrEmpty(token.TokenType))
                return token.TokenType;

            if (IsAllRigth(token))
                return TokenType;

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        protected virtual bool IsAllRigth(TextTokenInfo token)
        {
            return Scanners.All(a => a.IsAllRight(token));
        }
    }
}
