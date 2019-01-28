using System;
using System.Linq.Expressions;

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
        /// <param name="expression"></param>
        public void SetMethod(Expression<Action> expression)
        {
            var member = expression.Body as MethodCallExpression;
            MethodInfo = member?.Method;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        public void SetTimeOutMethod(Expression<Action> expression)
        {
            var member = expression.Body as MethodCallExpression;
            TimeOutMethodInfo = member?.Method;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        public void SetLimitExpiredMethod(Expression<Action> expression)
        {
            var member = expression.Body as MethodCallExpression;
            LimitExpiredMethodInfo = member?.Method;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invokeParams"></param>
        public void SetParams(params object[] invokeParams)
        {
            Params = invokeParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invokeParams"></param>
        public void SetTimeOutParams(params object[] invokeParams)
        {
            TimeOutParams = invokeParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invokeParams"></param>
        public void SetLimitExpiredParams(params object[] invokeParams)
        {
            LimitExpiredParams = invokeParams;
        }
    }
}
