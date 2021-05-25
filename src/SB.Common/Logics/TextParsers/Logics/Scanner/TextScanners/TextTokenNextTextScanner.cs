using System.Linq;

namespace SB.Common.Logics.TextParsers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTokenNextTextScanner : TextTokenTextScanner
    {
        /// <summary>
        /// 
        /// </summary>
        public int NextCount { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsAllRight(TextTokenInfo token)
        {
            var tokens = token.GetNextTokens().ToList();
            if (tokens.Count < NextCount)
                return false;

            return InternalIsAllRight(tokens[NextCount - 1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextCount"></param>
        public void WithNextCount(int nextCount)
        {
            NextCount = nextCount;
        }
    }
}