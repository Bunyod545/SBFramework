using System;

namespace SBCommon.Logics.Business.Registers.AccumulatingRegisters
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccumulatingTransaction : IIdentifiedTyped
    {
        /// <summary>
        /// 
        /// </summary>
        DateTime Moment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        TransactionDirection TransactionDirection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool Direction { get; set; }
    }
}