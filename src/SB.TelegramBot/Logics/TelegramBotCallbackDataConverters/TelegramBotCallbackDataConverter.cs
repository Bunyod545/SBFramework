using System.Linq;
using System.Reflection;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj) where T : class
        {
            if (obj == null)
                return string.Empty;

            var sbStringBuilder = new TelegramBotCallbackDataStringBuilder();
            var props = obj.GetType().GetProperties().ToList();
            props.ForEach(f => SerializePropertyValue(f, obj, sbStringBuilder));

            return sbStringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="obj"></param>
        /// <param name="builder"></param>
        private static void SerializePropertyValue(PropertyInfo prop, object obj, TelegramBotCallbackDataStringBuilder builder)
        {
            var converter = TelegramBotCallbackDataConverterFactory.GetConverter(prop.PropertyType);
            converter.Serialize(builder, prop.GetValue(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(string text) where T : class, new()
        {
            if (string.IsNullOrEmpty(text))
                return default(T);

            var stringValues = text.Split(';').SkipLast(1).ToList();
            var props = typeof(T).GetProperties().ToList();
            var obj = new T();

            for (int i = 0; i < stringValues.Count(); i++)
            {
                var stringValue = stringValues[i];
                if (props.Count == i)
                    break;

                var prop = props[i];
                var converter = TelegramBotCallbackDataConverterFactory.GetConverter(prop.PropertyType);

                var propValue = converter.Deserialize(prop.PropertyType, stringValue);
                prop.SetValue(obj, propValue);
            }

            return obj;
        }
    }
}
