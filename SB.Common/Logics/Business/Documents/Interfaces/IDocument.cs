using SBCommon.Logics.Metadata;

namespace SBCommon.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBDocumentType))]
    public interface IDocument : IIdentifiedTyped, ITImeStamped, ISubmitable
    {
    }
}
