using System;
using System.Collections.Generic;
using System.Text;

namespace SBCommon.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SBType
    {
        /// <summary>
        /// 
        /// </summary>
        public object CreateInstance()
        {
            return ClrType.GetConstructor(Type.EmptyTypes)?.Invoke(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Параметры</param>
        public object CreateInstance(object[] parameters)
        {
            return Activator.CreateInstance(ClrType, parameters);
        }
    }
}
