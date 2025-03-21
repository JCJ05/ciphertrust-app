using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ciphertrust_app.Model
{
    internal class ClienteDTO
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string direccion { get; set; }
        private string telefono { get; set; }
        private string dni { get; set; }
        private string user { get; set; }
        private string pass { get; set; }

        public ClienteDTO(int id, String nombre, string apellido, string direccion, string telefono, string dni, string user, string pass)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.dni = dni;
            this.user = user;
            this.pass = pass;
        }

        public ClienteDTO(string nombre, string apellido, string direccion, string telefono, string dni, string user, string pass)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.dni = dni;
            this.user = user;
            this.pass = pass;
        }

        public ClienteDTO(string nombre, string apellido, string direccion, string telefono, string dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.dni = dni;
        }

        public ClienteDTO(string nombre, string apellido, string direccion, string telefono, string dni, string user)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.dni = dni;
            this.user = user;
        }

    }
}
