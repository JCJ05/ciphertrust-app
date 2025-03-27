using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CADP.NetCore.Crypto;
using CADP.NetCore.Sessions;
using ciphertrust_app.Definition;
using crypto;
using Microsoft.VisualBasic.ApplicationServices;
using Serilog.Sinks.Syslog;
using static System.Collections.Specialized.BitVector32;
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

        public string? encryptDataWithSecretKey(string KeyName, NaeSession session, string data)
        {
            string? dataEncriptada = null;

            try
            {

                NaeRijndaelKey key = new NaeRijndaelKey(session, KeyName);

                string hexIV = "3ABBE543B526F36290658A066F6CA619";
                byte[] iv = HexStringToByteArray(hexIV);
                key.IV = iv;

                key.Padding = PaddingMode.PKCS7;
                key.Mode = CipherMode.CBC;

                byte[] encrBytes = null;

                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(data);

                ICryptoTransform encryptor = key.CreateEncryptor();
                System.IO.MemoryStream memstr = new System.IO.MemoryStream();
                CryptoStream encrstr = new CryptoStream(memstr, encryptor, CryptoStreamMode.Write);
                encrstr.Write(inputBytes, 0, inputBytes.Length);
                encrstr.Close();
                encrBytes = memstr.ToArray();
                Console.WriteLine("Encrypted Data (B64 encoded): {0}", Convert.ToBase64String(encrBytes));

                dataEncriptada = Convert.ToBase64String(encrBytes);
                Debug.WriteLine("dataEncriptada: ", dataEncriptada);

                byte[] decodedBytes = Convert.FromBase64String(dataEncriptada);

                // Paso 2: Convertir el arreglo de bytes a hexadecimal
                string hexString = BitConverter.ToString(decodedBytes).Replace("-", "");

                dataEncriptada = hexString;


            }
            catch (Exception e)
            {

                Console.WriteLine("Error al encriptar los datos: " + e.Message);

            }

            return dataEncriptada;

        }

        public static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
              bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;

          }
    public string? decryptDataWithSecretKey(string KeyName, NaeSession session, string data) {

            string desencriptarData = null;

            try
            {

                NaeRijndaelKey key = new NaeRijndaelKey(session, KeyName);

                byte[] decodedBytes = HexStringToByteArray(data);
                string base64String = Convert.ToBase64String(decodedBytes);
                Debug.WriteLine("base64string: ", base64String);

                string hexIV = "3ABBE543B526F36290658A066F6CA619";

                // Convertir la cadena hexadecimal a un arreglo de bytes
                byte[] iv = HexStringToByteArray(hexIV);

                key.IV = iv;
                key.Padding = PaddingMode.PKCS7;
                key.Mode = CipherMode.CBC;

                byte[] encrBytes = Convert.FromBase64String(base64String);

                ICryptoTransform decryptor = key.CreateDecryptor();
                System.IO.MemoryStream memstr2 = new System.IO.MemoryStream();
                CryptoStream decrstr = new CryptoStream(memstr2, key.CreateDecryptor(),
                CryptoStreamMode.Write);
                decrstr.Write(encrBytes, 0, encrBytes.Length);
                decrstr.Close();
                byte[] decrBytes = memstr2.ToArray();
                Console.WriteLine("Decrypted {0} bytes: {1}", Convert.ToString(decrBytes.Length),
                desencriptarData = new string(Encoding.UTF8.GetChars(decrBytes)));
                Debug.WriteLine("DataEncriptada: ", desencriptarData);

            }
            catch (Exception e) { 

                Debug.WriteLine("Error al desencriptar los datos: " + e.Message);

            }

            return desencriptarData;
            
        }

        public int generateRandomInteger()
        {
            int number = -1;
            try
            {
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    byte[] numberba = new byte[4];
                    rng.GetBytes(numberba);

                    // Convertir los bytes en un entero
                    number = BitConverter.ToInt32(numberba, 0);

                    if (number < 0)
                    {
                        number = -number;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("ERROR: Could not generate random integer: " + e.Message);
            }

            return number;
        }


    }
}
