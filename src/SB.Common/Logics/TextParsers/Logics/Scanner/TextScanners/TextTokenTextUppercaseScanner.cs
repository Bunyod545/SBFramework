namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenTextUppercaseScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            if (string.IsNullOrEmpty(token.TokenText))
                return false;

            return !string.IsNullOrWhiteSpace(token.TokenText) &&
                   token.TokenText.ToUpper() == token.TokenText;
        }
    }
}