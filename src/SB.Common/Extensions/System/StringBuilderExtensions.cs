namespace System.Text
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="condition"></param>
        /// <param name="text"></param>
        public static void AppendIf(this StringBuilder builder, bool condition, string text)
        {
            if (condition)
                builder?.Append(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="condition"></param>
        /// <param name="text"></param>
        public static void AppendLineIf(this StringBuilder builder, bool condition, string text)
        {
            if (condition)
                builder?.AppendLine(text);
        }
    }
}
