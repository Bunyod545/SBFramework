using System.Globalization;

namespace SB.TelegramBot.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotLanguageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        public static void InitializeCulture(string language)
        {
            if (string.IsNullOrEmpty(language))
                return;

            var culture = CultureInfo.GetCultureInfo(language);
            if (culture != null)
            {
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
        }
    }
}
