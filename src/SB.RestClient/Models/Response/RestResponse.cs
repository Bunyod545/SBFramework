using SB.RestClient.Models.ResponseError;
using SB.RestClient.Models.ResponseResult;

namespace SB.RestClient.Models.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class RestResponse<TResult, TError> : IRestResponse<TResult, TError>
    {
        /// <summary>
        /// 
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TError Error { get; set; }
    }
}
