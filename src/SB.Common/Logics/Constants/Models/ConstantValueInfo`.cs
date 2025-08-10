namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConstantValueInfo<T> : ConstantValueInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public new T Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConstantValueInfo()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public ConstantValueInfo(T value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator ConstantValueInfo<T>(T value)
        {
            return new ConstantValueInfo<T>(value);
        }
    }
}