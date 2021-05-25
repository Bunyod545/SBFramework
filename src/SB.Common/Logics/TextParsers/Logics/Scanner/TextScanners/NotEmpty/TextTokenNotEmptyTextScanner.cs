namespace SB.Common.Logics.TextParsers.Logics.Scanner.TextScanners.NotEmpty
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenNotEmptyTextScanner : TextTokenScanner
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

            return !string.IsNullOrWhiteSpace(token.TokenText);
        }
    }
}
