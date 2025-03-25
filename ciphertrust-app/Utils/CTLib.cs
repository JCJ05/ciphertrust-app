using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
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

                /*NaeRijndaelKey key = new NaeRijndaelKey(session, KeyName);

                byte[] iv = { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30, 0x31,
                    0x32, 0x33, 0x34, 0x35 };
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

                dataEncriptada = Convert.ToBase64String(encrBytes);*/

                /*byte[] iv = HexStringToByteArray("3ABBE543B526F36290658A066F6CA619");

                // Obtener la clave desde el HSM
                NaeRijndaelKey key = new NaeRijndaelKey(session, KeyName);

                // Convertir los datos a bytes
                byte[] inputBytes = Encoding.UTF8.GetBytes(data);

                // Configurar el cifrado AES en modo CBC con PKCS7 Padding
                using (Aes aesAlg = Aes.Create())
                {
                    // Aquí obtienes la clave del objeto NaeRijndaelKey
                    aesAlg.IV = iv;            // IV (Vector de Inicialización)
                    aesAlg.Mode = CipherMode.CBC;  // Modo CBC
                    aesAlg.Padding = PaddingMode.PKCS7; // Relleno PKCS7

                    // Crear el cifrador
                    using (ICryptoTransform encryptor = key.CreateEncryptor())
                    using (MemoryStream msEncrypt = new MemoryStream())
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(inputBytes, 0, inputBytes.Length);
                        csEncrypt.Close();

                        // Obtener el resultado encriptado
                        byte[] encryptedBytes = msEncrypt.ToArray();

                        // Codificar en Base64 (igual que en Java)
                        dataEncriptada = Convert.ToBase64String(encryptedBytes);
                        Console.WriteLine("Encrypted Data (Base64 encoded): " + dataEncriptada);
                    }
                }*/

                // El vector de inicialización (IV) debe ser el mismo en ambas implementaciones.
                byte[] iv = new byte[16];  // IV de 16 bytes para AES CBC
                new Random().NextBytes(iv);  // Para simular que IV es aleatorio, puedes usar otro método si lo prefieres.
                NaeRijndaelKey key = new NaeRijndaelKey(session, KeyName);
                 // Clave de ejemplo de 16 bytes para AES-128

                // Crear un objeto AES
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;  // PKCS5Padding en Java es lo mismo que PKCS7 en .NET
                    aesAlg.Key = key.Key;
                    aesAlg.IV = iv;

                    // Crear el cifrador
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Usar MemoryStream para almacenar los bytes cifrados
                    using (MemoryStream memstr = new MemoryStream())
                    using (CryptoStream encrstr = new CryptoStream(memstr, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(data);
                        encrstr.Write(inputBytes, 0, inputBytes.Length);
                        encrstr.Close();  // Esto cierra el stream y finaliza la encriptación

                        byte[] encrBytes = memstr.ToArray();
                        dataEncriptada = Convert.ToBase64String(encrBytes);

                        // Mostrar los datos cifrados en base64
                        Console.WriteLine("Encrypted Data (B64 encoded): {0}", Convert.ToBase64String(encrBytes));
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Error al encriptar los datos: " + e.Message);

            }

            return dataEncriptada;

        }

        public static byte[] HexStringToByteArray(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
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

                byte[] iv = { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30, 0x31,
                        0x32, 0x33, 0x34, 0x35 };
                key.IV = iv;

                key.Padding = PaddingMode.PKCS7;
                key.Mode = CipherMode.CBC;

                byte[] encrBytes = null;

                ICryptoTransform decryptor = key.CreateDecryptor();
                System.IO.MemoryStream memstr2 = new System.IO.MemoryStream();
                CryptoStream decrstr = new CryptoStream(memstr2, key.CreateDecryptor(),
                CryptoStreamMode.Write);
                decrstr.Write(encrBytes, 0, encrBytes.Length);
                decrstr.Close();
                byte[] decrBytes = memstr2.ToArray();
                Console.WriteLine("Decrypted {0} bytes: {1}", Convert.ToString(decrBytes.Length),
                desencriptarData = new string(Encoding.UTF8.GetChars(decrBytes)));

            }
            catch (Exception e) { 

                Console.WriteLine("Error al desencriptar los datos: " + e.Message);

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
