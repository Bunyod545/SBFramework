namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeNow
    {
        /// <summary>
        /// 
        /// </summary>
        public static DateTime? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime Now => Date ?? DateTime.Now;
    }
}
