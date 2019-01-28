using SB.Common.Logics.SynonymProviders.Helpers;
using SB.Common.Logics.SynonymProviders.Logics.SynonymMigration;

namespace SB.Common.Logics.SynonymProviders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SynonymInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [CultureInfo(CultureHelper.UzLanguageName)]
        public string Uz { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [CultureInfo(CultureHelper.RuLanguageName)]
        public string Ru { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [CultureInfo(CultureHelper.EnLanguageName)]
        public string En { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public SynonymInfo(string key)
        {
            Key = key;
        }

        /// <summary>
        /// 
        /// </summary>
        public SynonymInfo()
        {
            
        }
    }
}
