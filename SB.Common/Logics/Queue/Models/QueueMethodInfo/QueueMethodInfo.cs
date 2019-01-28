using System;
using System.Reflection;
using SB.Common.Logics.Queue.Enums;

namespace SB.Common.Logics.Queue.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class QueueMethodInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public QueueState State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public QueueInfo Owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime InvokeBeginDateTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime WaitInvokeBeginDateTime { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public object MethodObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object[] Params { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo MethodInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object[] TimeOutParams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo TimeOutMethodInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object[] LimitExpiredParams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo LimitExpiredMethodInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public QueueMethodInfo()
        {
            State = QueueState.WaitingInvoke;
        }
    }
}
