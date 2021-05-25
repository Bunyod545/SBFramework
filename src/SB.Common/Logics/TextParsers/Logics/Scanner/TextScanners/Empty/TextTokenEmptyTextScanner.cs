namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenEmptyTextScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            if (token.NextToken == null)
                return false;

            return string.IsNullOrWhiteSpace(token.TokenText);
        }
    }
}
