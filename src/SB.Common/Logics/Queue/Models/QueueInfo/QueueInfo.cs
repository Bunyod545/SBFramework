using System.Collections.Generic;
using System.Linq;
using SB.Common.Logics.Queue.Enums;
using SB.Common.Logics.Queue.Interfaces;

namespace SB.Common.Logics.Queue.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class QueueInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly object Locker = new object();

        /// <summary>
        /// 
        /// </summary>
        public IQueueIdentifier Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SynchronousActionsCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LimitCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TimeOutMilliSecound { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int WaitTimeOutMilliSecound { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal List<QueueMethodInfo> QueueMethodInfos { get; }

        /// <summary>
        /// 
        /// </summary>
        public int InvokingMethodsCount => QueueMethodInfos.Count(c => c.State == QueueState.CanInvoke);

        /// <summary>
        /// 
        /// </summary>
        public bool IsLimitExpired => !(QueueMethodInfos.Count - InvokingMethodsCount < LimitCount);

        /// <summary>
        /// 
        /// </summary>
        public QueueInfo()
        {
            QueueMethodInfos = new List<QueueMethodInfo>();
        }
    }
}
