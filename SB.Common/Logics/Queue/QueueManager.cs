using System.Collections.Generic;
using System.Linq;
using SB.Common.Logics.Queue.Enums;
using SB.Common.Logics.Queue.Models;

namespace SB.Common.Logics.Queue
{
    /// <summary>
    /// 
    /// </summary>
    public class QueueManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly object Locker = new object();

        /// <summary>
        /// 
        /// </summary>
        public static List<QueueInfo> QueueInfos { get; }

        /// <summary>
        /// 
        /// </summary>
        public QueueInfo QueueInfo { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        static QueueManager()
        {
            QueueInfos = new List<QueueInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queueInfo"></param>
        public QueueManager(QueueInfo queueInfo)
        {
            QueueInfo = queueInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodInfo"></param>
        public QueueWaitResult AddToWaitInvoke(QueueMethodInfo methodInfo)
        {
            lock (Locker)
            {
                InitializeQueueInfo();
                methodInfo.State = QueueState.WaitBeforeInvoke;
                return QueueInfo.AddToWaitInvoke(methodInfo);
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
                InitializeQueueInfo();

            return QueueInfo.Invoke<T>(methodInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeQueueInfo()
        {
            var findItem = QueueInfos.ToList().FirstOrDefault(f => 
                f.Identifier != null && 
                f.Identifier.IsEqual(QueueInfo.Identifier));

            if (findItem == null)
            {
                QueueInfos.Add(QueueInfo);
                return;
            }

            QueueInfo = findItem;
        }
    }
}
