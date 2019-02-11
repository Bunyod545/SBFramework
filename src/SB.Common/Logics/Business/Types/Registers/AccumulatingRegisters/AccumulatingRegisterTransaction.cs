using System;

namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class AccumulatingRegisterTransaction : SBObject, IAccumulatingTransaction
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TransactionDirection TransactionDirection
        {
            get => Direction ? TransactionDirection.Income : TransactionDirection.Outcome;
            set => Direction = value == TransactionDirection.Income;
        }
    }
}
