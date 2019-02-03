using SBCommon.Logics.Metadata;

namespace SBCommon.Logics.Business.Documents
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBDocumentType))]
    public interface IDocument : IIdentifiedTyped, ITImeStamped, ISubmitable
    {
    }
}
