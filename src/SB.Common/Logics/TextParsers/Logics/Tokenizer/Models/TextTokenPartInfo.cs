using System.Collections.Generic;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenPartInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TextTokenInfo> Tokens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PartNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TokensCount => Tokens.Count;

        /// <summary>
        /// 
        /// </summary>
        public TextTokenPartInfo PreviousPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextTokenPartInfo NextPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Part number: {PartNumber}, Tokens count: {TokensCount}";
        }
    }
}