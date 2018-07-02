using System;
using System.Runtime.InteropServices;
using System.Security;

namespace fasetto_word.Infrastructure.Secure
{
    /// <summary>
    /// helper for the <see cref="SecureString"/>
    /// </summary>
    public static class SecureStringHelper
    {
        public static string UnSecure(this SecureString secureString)
        {
            if (secureString == null) return string.Empty;

            //get a unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}