namespace SB.RestClient.Models.Response
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRestResponse<TResult, TError> 
    {
        /// <summary>
        /// 
        /// </summary>
        TResult Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        TError Error { get; set; }
    }
}