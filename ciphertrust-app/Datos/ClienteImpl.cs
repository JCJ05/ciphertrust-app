using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CADP.NetCore.Sessions;
using ciphertrust_app.Model;
using ciphertrust_app.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ciphertrust_app.Datos
{
    internal class ClienteImpl
    {

        public ClienteDTO? iniciarSesion(string user, string pass)
        {

            string encriptado = Encriptar.Sha256(pass);
            Debug.WriteLine("Password encriptado: " + encriptado);

            string sql = "select * from Cliente " +
                    "Where User = '" + user + "'" +
                    "and pass = '" + encriptado + "'";

            SQLite bd = new SQLite();
            SQLiteDataReader? dataReader = bd.ejecutarQuery(sql);
            ClienteDTO? cliente = null;

            if (dataReader != null)
            {
                
                    while (dataReader.Read())
                    {
                        int id = (int)(long)dataReader["Id"];
                        string nombre = (string)dataReader["Nombre"];
                        string apellido = (string)dataReader["Apellido"];
                        string direccion = (string)dataReader["Direccion"];
                        string telefono = (string)dataReader["Telefono"];
                        string dni = (string)dataReader["Dni"];
                        string usuario = (string)dataReader["User"];
                        string contra = (string)dataReader["Pass"];

                        cliente = new ClienteDTO(id, nombre, apellido, direccion, telefono, dni, usuario, contra);
                  
                    }
             
            }else
            {
                Console.WriteLine("No se pudo obtener datos del cliente.");

            }

            return cliente;
        }

        public List<ClienteDTO>? obtenerTodos()
        {
            List<ClienteDTO>? lista = null;

            string sql = "select * from Cliente where Dni != '77777777'";
            SQLite bd = new SQLite();
            SQLiteDataReader? dataReader = bd.ejecutarQuery(sql);

            if (dataReader != null)
            {
                lista = new List<ClienteDTO>();

                while (dataReader.Read())
                {
                    int id = (int)(long)dataReader["Id"];
                    string nombre = (string)dataReader["Nombre"];
                    string apellido = (string)dataReader["Apellido"];
                    string direccion = (string)dataReader["Direccion"];
                    string telefono = (string)dataReader["Telefono"];
                    string dni = (string)dataReader["Dni"];
                    string user = (string)dataReader["User"];
                    lista.Add(new ClienteDTO(id, nombre, apellido, direccion, telefono, dni, user, ""));
                }


            }
            else {

                Console.WriteLine("No se pudo obtener datos de los clientes.");

            }

             return lista;
        }

        public ClienteDTO? obtenerPorDni(string dniCliente)
        {

            ClienteDTO? cliente;
            string sql = "select * from Cliente " +
                    "Where Dni = '" + dniCliente + "'";

            SQLite bd = new SQLite();

            SQLiteDataReader? dataReader = bd.ejecutarQuery(sql);
            cliente = new ClienteDTO(0, "", "", "", "", "", "", "");

            if (dataReader != null)
            {

                while (dataReader.Read())
                {
                    cliente.id = (int)(long)dataReader["Id"];
                    cliente.nombre = (string)dataReader["Nombre"];
                    cliente.apellido = (string)dataReader["Apellido"];
                    cliente.direccion = (string)dataReader["Direccion"];
                    cliente.telefono = (string)dataReader["Telefono"];
                    cliente.dni = (string)dataReader["Dni"];
                    cliente.user = (string)dataReader["User"];

                    try {

                        cliente.pass = (string)dataReader["Pass"];

                    } catch {

                        cliente.pass = "";
                        Debug.WriteLine("El usuario no tiene contraseña");
                        
                    }



                }


            }
            else {

                cliente = null;
                Console.WriteLine("No se pudo obtener datos del cliente.");

            }

           return cliente;
        }

        public bool registrar(ClienteDTO cliente)
        {

            string? encryptedDireccion = null;
            string? encryptedTelefono = null;
            int numeroAleatorio = -1;
            bool registro = false;

            CTLib ctencryption = new CTLib();
            NaeSession? sesion = ctencryption.obtainSession(Definition.Definition.CT_USERNAME, Definition.Definition.CT_PASSWORD);

            if (sesion != null)
            {
                encryptedDireccion = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.direccion);

                encryptedTelefono = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.telefono);

                numeroAleatorio = ctencryption.generateRandomInteger();

                if (encryptedDireccion != null && encryptedTelefono != null && numeroAleatorio > 0)
                {
                    string sql = "INSERT INTO Cliente (Aleatorio, Nombre, Apellido, Direccion, Telefono, Dni)" +
                   "values(" +
                   numeroAleatorio + ",'" +
                   cliente.nombre + "','" +
                   cliente.apellido + "','" +
                   encryptedDireccion + "','" +
                   encryptedTelefono + "','" +
                   cliente.dni + "')";

                    SQLite bd = new SQLite();
                    registro = bd.ejecutarUpdate(sql);
                }
                else
                {
                    Console.WriteLine("No se pudo encriptar.");
                }
              
            }
            else
            {
                Console.WriteLine("No se pudo obtener sesión para encriptar.");
            }

            return registro;
        }

        public ClienteDTO registrarConUsuario(ClienteDTO cliente)
        {

            string? encryptedDireccion = null;
            string? encryptedTelefono = null;
            int numeroAleatorio = -1;

            CTLib ctencryption = new CTLib();
            NaeSession? sesion = ctencryption.obtainSession(Definition.Definition.CT_USERNAME, Definition.Definition.CT_PASSWORD);

            if (sesion != null)
            {
                encryptedDireccion = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.direccion);

                encryptedTelefono = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.telefono);

                numeroAleatorio = ctencryption.generateRandomInteger();

                if (encryptedDireccion != null && encryptedTelefono != null && numeroAleatorio > 0)
                {
                    
                    string sql = "INSERT INTO Cliente (Aleatorio, Nombre, Apellido, Direccion, Telefono, User, Dni)" +
                            "values(" +
                            numeroAleatorio + ",'" +
                            cliente.nombre + "','" +
                            cliente.apellido + "','" +
                            encryptedDireccion + "','" +
                            encryptedTelefono + "','" +
                            cliente.user + "','" +
                            cliente.dni + "')";

                    SQLite bd = new SQLite();

                    cliente.direccion =  encryptedDireccion;
                    cliente.telefono = encryptedTelefono;

                    bool rspta = bd.ejecutarUpdate(sql);

                    if (!rspta)
                    {
                        cliente.direccion = "";
                    }
                }
                else
                {
                    Console.WriteLine("No se pudo encriptar");
                    cliente.direccion = null;
                }
               
            }
            else
            {
                Console.WriteLine("No se pudo obtener sesión para encriptar.");
            }

            return cliente;
        }

        public bool actualizar(ClienteDTO cliente, string dni)
        {

            bool actualizar = false;

            string? encryptedDireccion = null;
            string? encryptedTelefono = null;

            CTLib ctencryption = new CTLib();
            NaeSession? sesion = ctencryption.obtainSession(Definition.Definition.CT_USERNAME, Definition.Definition.CT_PASSWORD);

            if (sesion != null)
            {
                encryptedDireccion = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.direccion);

                encryptedTelefono = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.telefono);

                if (encryptedDireccion != null && encryptedTelefono != null)
                {
                    string sql = "UPDATE Cliente set Nombre='" + cliente.nombre + "',"
                    + "Apellido='" + cliente.apellido + "',"
                    + "Direccion='" + encryptedDireccion + "',"
                    + "Telefono='" + encryptedTelefono + "',"
                    + "Dni='" + cliente.dni + "'"
                    + " where Dni='" + dni + "'";

                    SQLite bd = new SQLite();
                    actualizar = bd.ejecutarUpdate(sql);
                }
                else
                {
                    Console.WriteLine("No se pudo encriptar.");
                }
              
            }
            else
            {
                Console.WriteLine("No se pudo obtener sesión para encriptar.");
            }

            return actualizar;
        }

        public int actualizarConUsuario(ClienteDTO cliente, string dni)
        {

            string? encryptedDireccion = null;
            string? encryptedTelefono = null;

            int codRetorno = 0;
            bool executeQuery = false;

            CTLib ctencryption = new CTLib();
            NaeSession? sesion = ctencryption.obtainSession(Definition.Definition.CT_USERNAME, Definition.Definition.CT_PASSWORD);

            if (sesion != null)
            {
                encryptedDireccion = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.direccion);

                encryptedTelefono = ctencryption.encryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                        sesion,
                        cliente.telefono);

                if (encryptedDireccion != null && encryptedTelefono != null)
                {
                    string sql = "UPDATE Cliente set Nombre='" + cliente.nombre + "',"
                    + "Apellido='" + cliente.apellido + "',"
                    + "Direccion='" + encryptedDireccion + "',"
                    + "Telefono='" + encryptedTelefono + "',"
                    + "User='" + cliente.user + "',"
                    + "Dni='" + cliente.dni + "'"
                    + " where Dni='" + dni + "'";

                    SQLite bd = new SQLite();
                    executeQuery = bd.ejecutarUpdate(sql);

                    if (executeQuery)
                    {
                        codRetorno = 1;
                    }
                    else
                    {
                        codRetorno = 4; //No se pudo guardar en BD
                    }
                }
                else
                {
                    Console.WriteLine("No se pudo encriptar.");
                    codRetorno = 2; //Error cuando no se pudo encriptar
                }
               
            }
            else
            {
                Console.WriteLine("No se pudo obtener sesión para encriptar.");
                codRetorno = 3; //Error cuando no se pudo obtener sesion
            }

          
            return codRetorno;
        }

        public bool actualizarPass(ClienteDTO cliente, string dni)
        {

            string encriptado = "";
            encriptado = Encriptar.Sha256(cliente.pass);
     

            string sql = "UPDATE Cliente set Pass='" + encriptado + "'"
                    + " where Dni='" + dni + "'";

            SQLite bd = new SQLite();
            return bd.ejecutarUpdate(sql);
        }

        public bool eliminar(string dni)
        {
            string sql = "delete from Cliente where Dni='" + dni + "'";

            SQLite bd = new SQLite();
            return bd.ejecutarUpdate(sql);

        }

        public ClienteDTO desencriptar(ClienteDTO cli)
        {

            string? dataDireccion = "";
            string? dataTelefono = "";

            CTLib ctdecryption = new CTLib();

            NaeSession? sesion = ctdecryption.obtainSession(Definition.Definition.CT_USERNAME, Definition.Definition.CT_PASSWORD);
            if (sesion != null)
            {

                dataDireccion = ctdecryption.decryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                            sesion,
                            cli.direccion);

                dataTelefono = ctdecryption.decryptDataWithSecretKey(Definition.Definition.CT_AES_KEYNAME,
                            sesion,
                            cli.telefono);
                if (dataDireccion != null && dataTelefono != null)
                {
                    cli.direccion =  dataDireccion;
                    cli.telefono =  dataTelefono;
                }
                else
                {
                    Console.WriteLine("No se pudo desencriptar todos los datos.");
                }
              
            }
            else
            {
                Console.WriteLine("No se pudo obtener sesión para encriptar.");
            }

         
            return cli;
        }
    }
}
