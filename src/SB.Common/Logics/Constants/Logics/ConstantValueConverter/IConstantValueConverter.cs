namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConstantValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        ConstantSet Constant { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsCanConvert(object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object? Convert(object value);
    }
}