using SB.Common.Logics.SbStringConverters.Builders;
using System;

namespace SB.Common.Logics.SbStringConverters.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISbStringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        void Serialize(SbStringBuilder sbStringBuilder, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        object Deserialize(Type type, string value);
    }
}
