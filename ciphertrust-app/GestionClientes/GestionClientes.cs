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
    public static Image ICON = Image.FromFile(@"C:\Users\DESARROLLO\Documents\ciphertrust-app-net\ciphertrust-app\ciphertrust-app\Imagenes\IconMEF.png");
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}