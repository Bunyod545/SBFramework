using System;
using System.Globalization;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class CultureInfoAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CultureInfo CultureInfo => CultureInfo.GetCultureInfo(Name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public CultureInfoAttribute(string name)
        {
            Name = name;
        }
    }
}
