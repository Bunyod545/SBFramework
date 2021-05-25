using System.Collections.Generic;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextParseOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public TextTokenizer Tokenizer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenPrepare> Prepares { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenFilter> Filters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenAnalyzer> Analyzers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenFilter> AfterAnalyzeFilters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextParseOptions()
        {
            Prepares = new List<TextTokenPrepare>();
            Filters = new List<TextTokenFilter>();
            Analyzers = new List<TextTokenAnalyzer>();
            AfterAnalyzeFilters = new List<TextTokenFilter>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public TextParseOptions UseTokenizer<T>() where T : TextTokenizer, new()
        {
            Tokenizer = new T();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddPrepare<T>() where T : TextTokenPrepare, new()
        {
            var prepare = new T();
            Prepares.Add(prepare);
            return prepare;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddAnalyzer<T>(T analyzer) where T : TextTokenAnalyzer
        {
            Analyzers.Add(analyzer);
            return analyzer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddAnalyzer<T>() where T : TextTokenAnalyzer, new()
        {
            var analayzer = new T();
            Analyzers.Add(analayzer);
            return analayzer;
        }
    }
}
