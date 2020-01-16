using System;
using SB.Common.Logics.SynonymProviders;

namespace SB.Common
{
    /// <summary>
    /// Response error model
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// Response error code
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Response error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Response error model
        /// </summary>
        public ResponseError()
        {

        }

        /// <summary>
        /// Response error model
        /// </summary>
        /// <param name="errorEnum">Error enum</param>
        public ResponseError(Enum errorEnum)
        {
            ErrorCode = (int)(object)errorEnum;
            ErrorMessage = EnumSynonymProvider.Get(errorEnum);
        }

        /// <summary>
        /// Response error model
        /// </summary>
        /// <param name="errorCode">Response error code</param>
        /// <param name="errorMessage">Response error message</param>
        public ResponseError(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}