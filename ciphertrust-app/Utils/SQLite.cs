using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X509.Qualified;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ciphertrust_app.Utils
{
    internal class SQLite
    {

        private readonly string connectionString = @"Data Source=C:\Users\DESARROLLO\Documents\NetBeansProjects\ciphertrust-demo-app\db_gestion_clientes.db;Version=3;";

        public SQLiteConnection? GetConnection()
        {

            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(connectionString);
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("Error al obtener la conexión: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
            }

            return conn;
        }


        public SQLiteDataReader? ejecutarQuery(string querySQL)
        {

            SQLiteDataReader dataReader = null;
            SQLiteConnection conn = GetConnection();

            try
            {
            
                if (conn != null)
                {
                    conn.Open();
                    var command = new SQLiteCommand(querySQL, conn);
                    dataReader = command.ExecuteReader();
                }
                else
                {

                    Console.WriteLine("Error al obtener la conexión");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            return dataReader;
        }

        public bool ejecutarUpdate(string querySQL)
        {

            bool result = false;
            SQLiteConnection connection = GetConnection();

            try
            {
               
                if (connection != null)
                {

                    connection.Open();
                    var command = new SQLiteCommand(querySQL, connection);

                    if (command.ExecuteNonQuery() != 0)
                    {
                        result = true;
                    }
                    else
                    {

                        result = false;
                        Console.WriteLine("Error al realizar la operacion en la BD");

                    }

                }
                else { 
                    
                    result = false;
                    Console.WriteLine("Error al obtener la conexión");

                }

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
                cerrar(connection);
            }

            return result;
        }

        public void cerrar(SQLiteConnection connection)
        {
            if (connection != null)
            {
                try
                {
                    connection.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
                }
            }
        }


    }
}
