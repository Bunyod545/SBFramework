using System.Globalization;

namespace SB.Common.Logics.SynonymProviders.Logics.SynonymCulture
{
    /// <summary>
    /// 
    /// </summary>
    public class ThreadSafeSynonymCultureService : ISynonymCultureService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetCulture()
        {
            return CultureHelper.ThreadSafeCulture.Value ?? CultureInfo.CurrentCulture;
        }
    }
}
