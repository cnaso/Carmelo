using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Convenience extensions for <see cref="SecureString"/>.
    /// </summary>
    public static class SecureStringExtension
    {
        /// <summary>
        /// Hashes a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Hash(this SecureString secureString)
        {
            if (secureString == null)
            {
                return string.Empty;
            }

            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                string hash = BCrypt.Net.BCrypt.HashPassword(Marshal.PtrToStringUni(unmanagedString), 14);

                return hash;
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

            return string.Empty;
        }
    }
}
