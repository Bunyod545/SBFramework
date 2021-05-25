using System.Text.RegularExpressions;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenTextScanner : TextTokenScanner
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextTokenTextScannerType TextScannerType { get; set; }

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

            if (string.IsNullOrEmpty(token.TokenText))
                return false;

            if (string.IsNullOrEmpty(Text))
                return false;

            if (TextScannerType == TextTokenTextScannerType.Equal)
                return token.TokenText == Text;

            if (TextScannerType == TextTokenTextScannerType.StartsWith)
                return token.TokenText.StartsWith(Text);

            if (TextScannerType == TextTokenTextScannerType.EndsWith)
                return token.TokenText.EndsWith(Text);

            if (TextScannerType == TextTokenTextScannerType.Contains)
                return token.TokenText.Contains(Text);

            if (TextScannerType == TextTokenTextScannerType.Regex)
                return new Regex(Text).IsMatch(token.TokenText);

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void WithText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textScannerType"></param>
        public void WithTextScannerType(TextTokenTextScannerType textScannerType)
        {
            TextScannerType = textScannerType;
        }
    }
}
