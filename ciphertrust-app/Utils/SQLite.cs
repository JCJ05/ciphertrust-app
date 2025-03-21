using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ciphertrust_app.Utils
{
    internal class SQLite
    {

        private readonly string connectionString = @"Data Source=C:\Users\jaguero\Downloads\db_gestion_clientes.db;Version=3;";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        
    }
}
