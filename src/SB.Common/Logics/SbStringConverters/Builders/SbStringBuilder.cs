using SB.Common.Helpers;
using System.Text;

namespace SB.Common.Logics.SbStringConverters.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public class SbStringBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private StringBuilder _stringBuilder;

        /// <summary>
        /// 
        /// </summary>
        public SbStringBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void AppendEmptyValue()
        {
            AppendValue(string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void AppendValue(string text)
        {
            _stringBuilder.Append(text);
            _stringBuilder.Append(Strings.Semicolon);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
