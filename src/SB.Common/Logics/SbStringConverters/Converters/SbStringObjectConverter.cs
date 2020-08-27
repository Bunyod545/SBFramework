using SB.Common.Logics.SbStringConverters.Builders;
using System;

namespace SB.Common.Logics.SbStringConverters.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class SbStringObjectConverter : ISbStringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(SbStringBuilder sbStringBuilder, object value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            throw new NotImplementedException();
        }
    }
}
