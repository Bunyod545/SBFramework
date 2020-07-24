using System;

namespace SB.Common.Logics.ExceptionTree.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTreeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static Type[] ExcludesTypes =
        {
            typeof(bool),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(IntPtr),
            typeof(UIntPtr),
            typeof(char),
            typeof(double),
            typeof(float),
            typeof(DateTime),
            typeof(string)
        };
    }
}
