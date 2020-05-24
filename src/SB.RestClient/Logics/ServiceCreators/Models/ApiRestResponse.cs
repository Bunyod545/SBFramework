using System;
using SB.RestClient.Models.Response;

namespace SB.RestClient.Logics.ServiceCreators.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TError"></typeparam>
    public class ApiRestResponse<TResult, TError> : IRestResponse<TResult, TError>
    {
        /// <summary>
        /// 
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TError Error { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; set; }
    }
}
