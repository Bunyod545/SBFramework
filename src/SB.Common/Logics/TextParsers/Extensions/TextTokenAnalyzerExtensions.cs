namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TextTokenAnalyzerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        public static T UseScannerWith<T>(this TextTokenAnalyzer analyzer) where T : TextTokenScanner, new()
        {
            var scanner = new T();
            analyzer.Scanners.Add(scanner);
            return scanner;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        public static TextTokenAnalyzer UseScanner<T>(this TextTokenAnalyzer analyzer) where T : TextTokenScanner, new()
        {
            analyzer.Scanners.Add(new T());
            return analyzer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        public static TextTokenAnalyzer UseScanner<T>(this TextTokenAnalyzer analyzer, T scanner) where T : TextTokenScanner
        {
            analyzer.Scanners.Add(scanner);
            return analyzer;
        }
    }
}