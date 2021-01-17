namespace SB.Common.Helpers.Words
{
    /// <summary>
    /// 
    /// </summary>
    public static class TranscriptionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Translate(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var lowerText = text.ToLower();
            return Replace(lowerText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string Replace(string text)
        {
            foreach (var item in TranslationHelper.Replacements)
                text = text.Replace(item.Key, item.Value);

            return text;
        }
    }
}
