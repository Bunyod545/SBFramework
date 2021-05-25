using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextRegexTokenizer : TextTokenizer
    {
        /// <summary>
        /// 
        /// </summary>
        public string Splitter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="splitter"></param>
        public TextRegexTokenizer(string splitter)
        {
            Splitter = splitter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textParts"></param>
        /// <returns></returns>
        public override List<TextTokenPartInfo> GetTokens(List<TextPartInfo> textParts)
        {
            var partInfos = textParts.Select(GetTokenPart).ToList();
            TextTokenizerHelper.FillTokenPartsReferences(partInfos);

            return partInfos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textPart"></param>
        /// <returns></returns>
        private TextTokenPartInfo GetTokenPart(TextPartInfo textPart)
        {
            var info = new TextTokenPartInfo();
            info.PartNumber = textPart.PartNumber;

            var texts = Regex.Split(textPart.Text, Splitter);
            info.Tokens = texts.Select(s => GetToken(textPart.PartNumber, s)).ToList();

            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partNumber"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private TextTokenInfo GetToken(int partNumber, string text)
        {
            var token = new TextTokenInfo();
            token.TokenText = text;
            token.TokenPartNumber = partNumber;

            return token;
        }
    }
}
