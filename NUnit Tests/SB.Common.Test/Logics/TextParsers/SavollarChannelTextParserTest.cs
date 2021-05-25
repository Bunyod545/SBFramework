using NUnit.Framework;
using SB.Common.Logics.TextParsers;
using SB.Common.Test.Logics.TextParsers.Helpers;

namespace SB.Common.Test.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class SavollarChannelTextparserTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ParseTest()
        {
            var text = TextParserTexts.TestText;

            var parseOptions = new TextParseOptions();
            parseOptions.UseTokenizer<TextNewLineTokenizer>();
            QuestionTitleOptions(parseOptions);
            QuestionContentOptions(parseOptions);

            var parseResult = TextParser.Parse(text, parseOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parseOptions"></param>
        private void QuestionTitleOptions(TextParseOptions parseOptions)
        {
            var questionTitleAnalyzer = new TextTokenAnalyzer(TextParserTypes.QuestionTitle);
            parseOptions.AddAnalyzer(questionTitleAnalyzer);

            questionTitleAnalyzer.UseScanner<TextTokenTextUppercaseScanner>();
            questionTitleAnalyzer.UseScanner<TextTokenNextEmptyTextScanner>();

            var nextTokenScanner = new TextTokenNextTextScanner();
            nextTokenScanner.WithText("@Savollar_kanal");
            nextTokenScanner.WithTextScannerType(TextTokenTextScannerType.StartsWith);
            nextTokenScanner.WithNextCount(2);
            questionTitleAnalyzer.UseScanner(nextTokenScanner);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parseOptions"></param>
        private void QuestionContentOptions(TextParseOptions parseOptions)
        {
            var questionContentAnalyzer = new TextTokenAnalyzer(TextParserTypes.QuestionContent);
            parseOptions.AddAnalyzer(questionContentAnalyzer);

            var previousTokenScanner = new TextTokenPreviousTextScanner();
            previousTokenScanner.WithPreviousCount(2);
            previousTokenScanner.WithText("@Savollar_kanal");
            previousTokenScanner.WithTextScannerType(TextTokenTextScannerType.StartsWith);

            questionContentAnalyzer.UseScanner(previousTokenScanner);
            questionContentAnalyzer.UseScannerWith<TextTokenPreviousEmptyTextScanner>();
            questionContentAnalyzer.UseScannerWith<TextTokenNextEmptyTextScanner>();
        }
    }
}
