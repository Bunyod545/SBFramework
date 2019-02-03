using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SBCommon.Logics.PropertyValue
{
    /// <summary>
    /// 
    /// </summary>
    public static class NotifyPropertyChangeManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<Type> _initializedTypes;

        /// <summary>
        /// 
        /// </summary>
        static NotifyPropertyChangeManager()
        {
            _initializedTypes = new List<Type>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize(Type type)
        {
            lock (_initializedTypes)
                InternalInitialize(type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private static void InternalInitialize(Type type)
        {
            if (_initializedTypes.Contains(type))
                return;

            _initializedTypes.Add(type);
        }
    }
}
