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
            var text = TextParserTexts.TestTextOldVersion;

            var parseOptions = new TextParseOptions();
            parseOptions.UseTokenizer<TextNewLineTokenizer>();
            QuestionTitleOptions(parseOptions);

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

            var previousTokenScanner = new TextTokenPreviousTextScanner();
            previousTokenScanner.WithText("^[0-9]*-савол");
            previousTokenScanner.WithTextScannerType(TextTokenTextScannerType.Regex);
            
            questionTitleAnalyzer.UseScanner(previousTokenScanner);
            questionTitleAnalyzer.UseScanner<TextTokenNextEmptyTextScanner>();
        }
    }
}
