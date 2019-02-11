namespace SB.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToSafeString(this object obj, string defaultValue = "")
        {
            return obj?.ToString() ?? defaultValue;
        }
    }
}
