using System;

namespace SBCommon.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBTypeAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type SBType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbType"></param>
        public SBTypeAttribute(Type sbType)
        {
            if (sbType == null || !sbType.IsSubclassOf(typeof(SBType)))
                throw new ArgumentException(nameof(sbType));

            SBType = sbType;
        }
    }
}
