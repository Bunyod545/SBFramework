using System;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SBType
    {
        /// <summary>
        /// 
        /// </summary>
        public long TypeId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; private set;}

        /// <summary>
        /// 
        /// </summary>
        public bool IsPrimitive { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize(SBTypeInfo info)
        {
            TypeId = info.TypeId;
            ClrType = info.ClrType;
            IsPrimitive = info.IsPrimitive;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"TypeId: {TypeId}, ClrType: {ClrType.Name}, IsPrimitive: {IsPrimitive}";
        }
    }
}
