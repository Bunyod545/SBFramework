using System.Globalization;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class CultureHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const string UzLanguageName = "uz-Latn-UZ";

        /// <summary>
        /// 
        /// </summary>
        public const string RuLanguageName = "ru-RU";

        /// <summary>
        /// 
        /// </summary>
        public const string EnLanguageName = "en";

        /// <summary>
        /// 
        /// </summary>
        public static CultureInfo UzLanguage => CultureInfo.GetCultureInfo(UzLanguageName);

        /// <summary>
        /// 
        /// </summary>
        public static CultureInfo RuLanguage => CultureInfo.GetCultureInfo(RuLanguageName);

        /// <summary>
        /// 
        /// </summary>
        public static CultureInfo EnLanguage => CultureInfo.GetCultureInfo(EnLanguageName);

        /// <summary>
        /// 
        /// </summary>
        public static bool IsUzLanguage => Equals(CultureInfo.CurrentCulture, UzLanguage);

        /// <summary>
        /// 
        /// </summary>
        public static bool IsRuLanguage => Equals(CultureInfo.CurrentCulture, RuLanguage);

        /// <summary>
        /// 
        /// </summary>
        public static bool IsEnLanguage => Equals(CultureInfo.CurrentCulture, EnLanguage);
    }
}
