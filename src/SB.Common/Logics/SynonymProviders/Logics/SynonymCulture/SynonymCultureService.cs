using System.Globalization;

namespace SB.Common.Logics.SynonymProviders.Logics.SynonymCulture
{
    /// <summary>
    /// 
    /// </summary>
    public class SynonymCultureService : ISynonymCultureService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetCulture()
        {
            return CultureInfo.CurrentCulture;
        }
    }
}
