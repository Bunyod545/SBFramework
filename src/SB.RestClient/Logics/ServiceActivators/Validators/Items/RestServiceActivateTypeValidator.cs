using System;

namespace SB.RestClient.Logics.ServiceActivators.Validators
{
    /// <summary>
    /// 
    /// </summary>
    public static class RestServiceActivateTypeValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Validate<T>()
        {
            var type = typeof(T);
            TypeIsInterace(type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private static void TypeIsInterace(Type type)
        {
            if (!type.IsInterface)
                throw new InvalidOperationException($"Type {type} must be interface");
        }
    }
}
