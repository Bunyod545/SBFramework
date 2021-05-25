using SB.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TextTokenizerHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parts"></param>
        public static void FillTokenPartsReferences(List<TextTokenPartInfo> parts)
        {
            for (int index = 0; index < parts.Count; index++)
                FillTokenPartReference(index, parts);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="page"></param>
        private static void FillTokenPartReference(int index, List<TextTokenPartInfo> parts)
        {
            var pageInfo = parts[index];

            var previousIndex = index - 1;
            if (previousIndex >= 0)
                pageInfo.PreviousPart = parts[previousIndex];

            var nextPrevious = index + 1;
            if (nextPrevious < parts.Count)
                pageInfo.NextPart = parts[nextPrevious];

            FillTokensReferences(pageInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        private static void FillTokensReferences(TextTokenPartInfo part)
        {
            for (int index = 0; index < part.TokensCount; index++)
                FillTokenReference(index, part);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="part"></param>
        private static void FillTokenReference(int index, TextTokenPartInfo part)
        {
            var token = part.Tokens[index];
            token.TokenPart = part;
            token.TokenPartNumber = part.PartNumber;
            token.TokenNumber = index + 1;
            token.PreviousToken = GetPreviousToken(index, part);
            token.NextToken = GetNextToken(index, part);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        private static TextTokenInfo GetPreviousToken(int index, TextTokenPartInfo part)
        {
            var tokens = part.Tokens;
            var token = tokens[index];

            var previousIndex = index - 1;
            if (previousIndex >= 0)
                return tokens[previousIndex];

            if (token.PreviousToken == null && index == 0)
                return part.PreviousPart?.Tokens?.LastOrDefault();

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        private static TextTokenInfo GetNextToken(int index, TextTokenPartInfo part)
        {
            var tokens = part.Tokens;
            var token = tokens[index];

            var nextPrevious = index + 1;
            if (nextPrevious < tokens.Count)
                return tokens[nextPrevious];

            if (token.NextToken == null && tokens.IsLast(token))
                return part.NextPart?.Tokens?.FirstOrDefault();

            return null;
        }
    }
}
