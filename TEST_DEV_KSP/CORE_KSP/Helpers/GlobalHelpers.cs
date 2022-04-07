using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CORE_KSP.Helpers
{
    public class GlobalHelpers
    {
        /// <summary>
        /// Encrypting a string value by Sha-256 algorithm
        /// </summary>
        /// <param name="data">String: received value to encrypt</param>
        /// <returns>String: encrypted value</returns>
        public static string EncryptToSHA256(string data)
        {
            var sb = new StringBuilder();
            var stream = SHA256.Create().ComputeHash(new ASCIIEncoding().GetBytes(data));
            for (int i = 0; i < stream.Length; i++)
                sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


    }
}
