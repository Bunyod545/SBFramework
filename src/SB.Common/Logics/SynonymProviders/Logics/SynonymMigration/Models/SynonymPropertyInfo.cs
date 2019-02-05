using SB.Common.Logics.SynonymProviders;
using System.Globalization;
using System.Reflection;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SynonymPropertyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CultureInfoAttribute CultureInfoAttribute { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CultureInfo CultureInfo => CultureInfoAttribute?.CultureInfo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="cultureInfoAttribute"></param>
        public SynonymPropertyInfo(PropertyInfo propertyInfo, CultureInfoAttribute cultureInfoAttribute)
        {
            PropertyInfo = propertyInfo;
            CultureInfoAttribute = cultureInfoAttribute;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="synonymInfo"></param>
        /// <param name="value"></param>
        public void SetValue(SynonymInfo synonymInfo, string value)
        {
            PropertyInfo.SetValue(synonymInfo, value);
        }
    }
}
