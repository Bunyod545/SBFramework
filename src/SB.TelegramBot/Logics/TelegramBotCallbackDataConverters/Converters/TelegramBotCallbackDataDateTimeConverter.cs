using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataDateTimeConverter : ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value)
        {
            if(value == null)
            {
                sbStringBuilder.AppendEmptyValue();
                return;
            }

            var date = (DateTime)value;
            var millisecounds = new DateTimeOffset(date).ToUnixTimeMilliseconds();
            sbStringBuilder.AppendValue(millisecounds.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            if (value == string.Empty)
                return null;

            var millisecounds = long.Parse(value);
            return new DateTimeOffset().AddMilliseconds(millisecounds).Date;
        }
    }
}
