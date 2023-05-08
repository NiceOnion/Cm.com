using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class ExtensionMethod
    {
        public static string HashString(this string text)
        {
            var rng = new RNGCryptoServiceProvider();
            var byteSize = new byte[13];
            rng.GetBytes(byteSize);

            byte[] bytes = Encoding.UTF8.GetBytes(text + byteSize);
            SHA256Managed sha256 = new SHA256Managed();

            sha256.ComputeHash(bytes);

            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
