using System;
using System.Reflection;
using System.Threading;
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Invoke<T>()
        {
            InvokeBeginDateTime = DateTime.Now;

            while (true)
            {
                if (State == QueueState.LimitExpired)
                    return InternalInvokeMethod<T>(LimitExpiredMethodInfo, LimitExpiredParams);

                if (IsTimeOut())
                    return InternalInvokeMethod<T>(TimeOutMethodInfo, TimeOutParams);

                if (State == QueueState.CanInvoke)
                    return InternalInvokeMethod<T>(MethodInfo, Params);

                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool IsTimeOut()
        {
            if (State != QueueState.WaitingInvoke)
                return false;

            var limitTime = InvokeBeginDateTime.AddMilliseconds(Owner.TimeOutMilliSecound);
            if (limitTime < DateTime.Now)
                State = QueueState.TimeOut;

            return State == QueueState.TimeOut;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodInfo"></param>
        /// <param name="methodParams"></param>
        /// <returns></returns>
        private T InternalInvokeMethod<T>(MethodInfo methodInfo, object[] methodParams)
        {
            if (methodInfo == null)
            {
                Owner.RemoveMethodInfo(this);
                return default(T);
            }

            var res = (T)methodInfo.Invoke(MethodObject, methodParams);
            Owner.RemoveMethodInfo(this);
            return res;
        }
    }
}
