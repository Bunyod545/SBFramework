using System;

namespace SB.RestClient.Logics.ServiceCreators.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DynamicClassBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        public Type InterfaceType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceType"></param>
        public DynamicClassBuilder(Type interfaceType)
        {
            InterfaceType = interfaceType;
        }
    }
}
