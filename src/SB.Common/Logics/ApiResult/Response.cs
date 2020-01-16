namespace SB.Common
{
    /// <summary>
    /// Response model
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Response result
        /// </summary>
        public ResponseResult Result { get; set; }

        /// <summary>
        /// Response error
        /// </summary>
        public ResponseError Error { get; set; }

        /// <summary>
        /// Response model
        /// </summary>
        public Response()
        {
            
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        public Response(ResponseResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="error">Response error</param>
        public Response(ResponseError error)
        {
            Error = error;
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        /// <param name="error">Response error</param>
        public Response(ResponseResult result, ResponseError error)
        {
            Result = result;
            Error = error;
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        public static implicit operator Response(ResponseResult result)
        {
            return new Response(result);
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="error">Response error</param>
        public static implicit operator Response(ResponseError error)
        {
            return new Response(error);
        }
    }
}
