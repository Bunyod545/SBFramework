using System.Reflection;

namespace SB.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class BindingFlagsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const BindingFlags PublicFields = BindingFlags.Instance | BindingFlags.Public;

        /// <summary>
        /// 
        /// </summary>
        public const BindingFlags PrivateFields = BindingFlags.Instance | BindingFlags.NonPublic;

        /// <summary>
        /// 
        /// </summary>
        public const BindingFlags ObjectFields = PublicFields | PrivateFields;
    }
}
