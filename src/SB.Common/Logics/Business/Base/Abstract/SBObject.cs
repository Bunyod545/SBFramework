using SB.Common.Logics.Metadata;

namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SBObject : SBObjectBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override long GetTypeId()
        {
            return SBType.GetTypeId(this);
        }
    }
}
