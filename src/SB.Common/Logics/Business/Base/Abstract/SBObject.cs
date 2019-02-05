using SBCommon.Logics.Metadata;

namespace SBCommon.Logics.Business
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
