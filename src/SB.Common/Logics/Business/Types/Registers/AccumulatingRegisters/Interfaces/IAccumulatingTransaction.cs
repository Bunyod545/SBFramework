using System;

namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccumulatingTransaction : IIdentifiedTyped
    {
        /// <summary>
        /// 
        /// </summary>
        long RegistratorType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        long Registrator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime Moment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        long RowNumber { get; set; }

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