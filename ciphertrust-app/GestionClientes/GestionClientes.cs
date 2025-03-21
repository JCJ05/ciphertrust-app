using System.Data.SQLite;
using System.Diagnostics;
using CADP.NetCore.Crypto;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using CADP.NetCore.Sessions;
using ciphertrust_app.Definition;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ciphertrust_app.GestionClientes
{
    internal static class GestionClientes
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Debug.WriteLine("hoal mundo");
            string connectionString = @"Data Source=C:\Users\jaguero\Downloads\db_gestion_clientes.db;Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Apellido, Direccion, Telefono, Dni, \"User\", Pass, Aleatorio\r\nFROM Cliente;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}");
                    }
                }
            }

            /*NaeSession session = new NaeSession(Definition.Definition.CT_USERNAME, Definition.Definition.CT_PASSWORD, CTDefinition.CTMAN_PROPERTIES);

            NaeRijndaelKey key = new NaeRijndaelKey(session, Definition.Definition.CT_AES_KEYNAME);

            byte[] iv = { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30, 0x31,
                0x32, 0x33, 0x34, 0x35 };
            key.IV = iv;

            key.Padding = PaddingMode.PKCS7;
            key.Mode = CipherMode.CBC;
            byte[] encrBytes = null;

            string inputData = "Este es el texto que quiero cifrar";
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(inputData);

            ICryptoTransform encryptor = key.CreateEncryptor();
            System.IO.MemoryStream memstr = new System.IO.MemoryStream();
            CryptoStream encrstr = new CryptoStream(memstr, encryptor, CryptoStreamMode.Write);
            encrstr.Write(inputBytes, 0, inputBytes.Length);
            encrstr.Close();
            encrBytes = memstr.ToArray();
            Debug.WriteLine("Encrypted Data (B64 encoded): {0}", Convert.ToBase64String(encrBytes));/*/

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}