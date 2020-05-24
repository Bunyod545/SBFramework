using System;
using System.Collections.Generic;

namespace SB.RestClient.Logics.ServiceActivators.Validators
{
    /// <summary>
    /// 
    /// </summary>
    public class RestServiceActivateValidateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Type> ValidTypes { get; } = new List<Type>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Validate<T>()
        {
            if (ValidTypes.Contains(typeof(T)))
                return;

            RestServiceActivateTypeValidator.Validate<T>();
            RestServiceActivateMethodsValidator.Validate<T>();
            ValidTypes.Add(typeof(T));
        }
    }
}
