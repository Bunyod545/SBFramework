using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TextParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        public static TextParseResult Parse(string text, TextParseOptions options)
        {
            var textPartInfo = new TextPartInfo();
            textPartInfo.Text = text;
            textPartInfo.PartNumber = 1;

            var textParts = new List<TextPartInfo>();
            textParts.Add(textPartInfo);

            return Parse(textParts, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texts"></param>
        /// <param name="options"></param>
        public static TextParseResult Parse(List<TextPartInfo> texts, TextParseOptions options)
        {
            var tokenParts = options.Tokenizer.GetTokens(texts);
            PrepareTokens(options, tokenParts);
            FilterTokens(options.Filters, tokenParts);
            AnalyzeTokens(options, tokenParts);
            FilterTokens(options.AfterAnalyzeFilters, tokenParts);

            return new TextParseResult(tokenParts);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenParts"></param>
        private static void PrepareTokens(TextParseOptions options, List<TextTokenPartInfo> tokenParts)
        {
            options.Prepares.ForEach(f => PreparePagesTokens(f, tokenParts));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenPrepare"></param>
        /// <param name="tokenParts"></param>
        private static void PreparePagesTokens(TextTokenPrepare tokenPrepare, List<TextTokenPartInfo> tokenParts)
        {
            var tokens = tokenParts.SelectMany(s => s.Tokens).ToList();
            tokens.ForEach(f => tokenPrepare.Prepare(f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenParts"></param>
        private static void FilterTokens(List<TextTokenFilter> filters, List<TextTokenPartInfo> tokenParts)
        {
            tokenParts.ForEach(f => FilterPageTokens(f, filters));
            tokenParts.ForEach(f => f.Tokens.RemoveAll(r => r.IsIgrored));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenPart"></param>
        /// <param name="filters"></param>
        private static void FilterPageTokens(TextTokenPartInfo tokenPart, List<TextTokenFilter> filters)
        {
            tokenPart.Tokens.ForEach(f => FilterToken(f, filters));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filters"></param>
        private static void FilterToken(TextTokenInfo token, List<TextTokenFilter> filters)
        {
            if (filters.Any(f => f.IsCanFilter(token)))
                token.IsIgrored = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="tokenParts"></param>
        private static void AnalyzeTokens(TextParseOptions options, List<TextTokenPartInfo> tokenParts)
        {
            options.Analyzers.ForEach(f => AnalyzePartsTokens(f, tokenParts));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analyzer"></param>
        private static void AnalyzePartsTokens(TextTokenAnalyzer analyzer, List<TextTokenPartInfo> parts)
        {
            var tokens = parts.SelectMany(s => s.Tokens).ToList();
            tokens.ForEach(f => AnalyzeTokenType(analyzer, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analyzer"></param>
        /// <param name="token"></param>
        private static void AnalyzeTokenType(TextTokenAnalyzer analyzer, TextTokenInfo token)
        {
            if (!string.IsNullOrEmpty(token.TokenType))
                return;

            token.TokenType = analyzer.Analyze(token);
        }
    }
}
