using System.Globalization;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISynonymStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        string Get(string key, CultureInfo cultureInfo);
    }
}
