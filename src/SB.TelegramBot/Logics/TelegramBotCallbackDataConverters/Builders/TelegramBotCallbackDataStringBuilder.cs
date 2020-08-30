using System.Text;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataStringBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private StringBuilder _stringBuilder;

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCallbackDataStringBuilder()
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
            _stringBuilder.Append(";");
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
