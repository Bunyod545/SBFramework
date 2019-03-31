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
        public virtual long Registrator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Document CachedRegistrator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual long RegistratorType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime Moment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual long RowNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Direction { get; set; }

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
