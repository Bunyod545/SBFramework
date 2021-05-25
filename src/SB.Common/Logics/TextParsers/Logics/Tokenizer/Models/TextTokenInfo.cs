namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TokenText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsIgrored { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TokenPartNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TokenNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextTokenInfo PreviousToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextTokenInfo NextToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextTokenPartInfo TokenPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{TokenPartNumber}/{TokenNumber} {TokenType} - {TokenText}";
        }
    }
}