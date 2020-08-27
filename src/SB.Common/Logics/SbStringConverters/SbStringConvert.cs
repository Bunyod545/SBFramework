using SB.Common.Extensions;
using SB.Common.Logics.SbStringConverters.Builders;
using SB.Common.Logics.SbStringConverters.Converters;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.SbStringConverters
{
    /// <summary>
    /// 
    /// </summary>
    public static class SbStringConvert
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

            var sbStringBuilder = new SbStringBuilder();
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
        private static void SerializePropertyValue(PropertyInfo prop, object obj, SbStringBuilder builder)
        {
            var converter = SbStringConverterFactory.GetConverter(prop.PropertyType);
            converter.Serialize(builder, prop.GetValue(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(string text) where T: class, new()
        {
            if (string.IsNullOrEmpty(text))
                return default;

            var props = typeof(T).GetProperties().ToList();
            var value = new T();

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DeserializePropertyValue()
        {

        }
    }
}
