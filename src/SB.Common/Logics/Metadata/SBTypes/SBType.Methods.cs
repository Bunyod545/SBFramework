using System;
using SB.Common.Helpers;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SBType
    {
        /// <summary>
        /// 
        /// </summary>
        private void InternalInitialize()
        {
            try
            {
                Initialize();
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize()
        {

        }

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
