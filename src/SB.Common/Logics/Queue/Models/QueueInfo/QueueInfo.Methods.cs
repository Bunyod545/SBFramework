using System;
using System.Linq;
using SB.Common.Logics.Queue.Enums;
using SBCommon.Extensions;

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
        /// <param name="methodInfo"></param>
        public QueueWaitResult AddToWaitInvoke(QueueMethodInfo methodInfo)
        {
            lock (Locker)
            {
                RemoveWaitTimeoutItems();

                if (IsLimitExpired)
                    return QueueWaitResult.LimitExpired();

                methodInfo.WaitInvokeBeginDateTime = DateTime.Now;
                QueueMethodInfos.Add(methodInfo);
                return new QueueWaitResult();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RemoveWaitTimeoutItems()
        {
            var waitingItems = QueueMethodInfos.ToList(w => w.State == QueueState.WaitBeforeInvoke);
            foreach (var item in waitingItems)
            {
                var isTimeOut = item.WaitInvokeBeginDateTime.AddMilliseconds(WaitTimeOutMilliSecound) < DateTime.Now;
                if (isTimeOut)
                    QueueMethodInfos.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Invoke<T>(QueueMethodInfo methodInfo)
        {
            lock (Locker)
            {
                RemoveWaitBeforeInvoke();

                if (IsLimitExpired)
                    methodInfo.State = QueueState.LimitExpired;

                methodInfo.Owner = this;
                QueueMethodInfos.Add(methodInfo);
                CheckAndRun();
            }

            return methodInfo.Invoke<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RemoveWaitBeforeInvoke()
        {
            var waitingMethodInfo = QueueMethodInfos.FirstOrDefault(f =>
                f.State == QueueState.WaitBeforeInvoke);

            if (waitingMethodInfo != null)
                QueueMethodInfos.Remove(waitingMethodInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void RemoveMethodInfo(QueueMethodInfo info)
        {
            lock (Locker)
            {
                QueueMethodInfos.Remove(info);
                CheckAndRun();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckAndRun()
        {
            var canInvokeCount = SynchronousActionsCount - InvokingMethodsCount;
            if (canInvokeCount <= 0)
                return;

            var methods = QueueMethodInfos.Where(w =>
                w.State == QueueState.WaitingInvoke).Take(SynchronousActionsCount).ToList();

            methods.ForEach(f => f.State = QueueState.CanInvoke);
        }
    }
}
