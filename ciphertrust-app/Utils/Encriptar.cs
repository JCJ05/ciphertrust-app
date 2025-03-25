using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ciphertrust_app.Utils
{
    internal class Encriptar
    {
        public static string Sha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder hexString = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    hexString.AppendFormat("{0:x2}", b);
                }

                return hexString.ToString();
            }
        }
    }
}
