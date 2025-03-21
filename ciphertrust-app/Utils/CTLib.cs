using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CADP.NetCore.Crypto;
using CADP.NetCore.Sessions;
using ciphertrust_app.Definition;
using crypto;
using Serilog.Sinks.Syslog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ciphertrust_app.Utils
{
    internal class CTLib
    {

        public NaeSession? obtainSession(string username, string password)

        {
            NaeSession? session = null;

            try
            {

                session = new NaeSession(username, password, CTDefinition.CTMAN_PROPERTIES);

            }

            catch (Exception e)
            {

                Console.WriteLine("Error al obtener la sesión: " + e.Message);

            }

            return session;

        }

        public string encryptDataWithSecretKey(string KeyName , NaeSession session, string data)
        {
            NaeRijndaelKey key = new NaeRijndaelKey(session, KeyName);

            byte[] iv = { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30, 0x31,
                0x32, 0x33, 0x34, 0x35 };
            key.IV = iv;

            key.Padding = PaddingMode.PKCS7;
            key.Mode = CipherMode.CBC;

            byte[] encrBytes = null;

            string inputData = "Este es el texto que quiero cifrar";
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(data);

            ICryptoTransform encryptor = key.CreateEncryptor();
            System.IO.MemoryStream memstr = new System.IO.MemoryStream();
            CryptoStream encrstr = new CryptoStream(memstr, encryptor, CryptoStreamMode.Write);
            encrstr.Write(inputBytes, 0, inputBytes.Length);
            encrstr.Close();
            encrBytes = memstr.ToArray();
            Console.WriteLine("Encrypted Data (B64 encoded): {0}", Convert.ToBase64String(encrBytes));

            return Convert.ToBase64String(encrBytes);
        }


    }
}
