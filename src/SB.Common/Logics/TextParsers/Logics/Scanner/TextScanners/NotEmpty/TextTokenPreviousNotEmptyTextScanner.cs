namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenPreviousNotEmptyTextScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            if (token.PreviousToken == null)
                return false;

            return !string.IsNullOrWhiteSpace(token.PreviousToken.TokenText);
        }
    }
}
