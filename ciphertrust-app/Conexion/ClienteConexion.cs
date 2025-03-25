using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciphertrust_app.Datos;
using ciphertrust_app.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ciphertrust_app.Conexion
{
    internal class ClienteConexion
    {

        private List<ClienteDTO>? listClienteDTO;
        private ClienteDTO? clienteDTO;

        public ClienteConexion()
        {
            listClienteDTO = new List<ClienteDTO>();
        }

        public bool agregar(ClienteDTO cliente)
        {
            bool guardado = false;
            ClienteImpl bd = new ClienteImpl();
            guardado = bd.registrar(cliente);
            return guardado;
        }

        public ClienteDTO agregarConUsuario(ClienteDTO cliente)
        {
            ClienteDTO cli;
            ClienteImpl bd = new ClienteImpl();
            cli = bd.registrarConUsuario(cliente);
            return cli;
        }

        public ClienteDTO desencriptar(ClienteDTO cliente)
        {
            ClienteImpl imp = new ClienteImpl();
            return imp.desencriptar(cliente);
        }

        public void eliminar(int indice)
        {
            listClienteDTO.RemoveAt(indice);
        }


        public int? total()
        {
            return listClienteDTO.Count;
        }

        public ClienteDTO obtener(int indice)
        {
            return listClienteDTO.ElementAt(indice);
        }

        public ClienteDTO? iniciarSesion(string user, string pass)
        {
            ClienteImpl bd = new ClienteImpl();
            clienteDTO = bd.iniciarSesion(user, pass);
            return clienteDTO;
        }

        public ClienteDTO? obtenerPorDni(string dni)
        {
            ClienteImpl bd = new ClienteImpl();
            clienteDTO = bd.obtenerPorDni(dni);
            return clienteDTO;
        }

        public void cargarDesdeBD()
        {
            ClienteImpl bd = new ClienteImpl();
            listClienteDTO = bd.obtenerTodos();
        }

        public void agregarClienteTabla(ClienteDTO cliente)
        {
            listClienteDTO.Add(cliente);
        }

        public bool Actualizar(ClienteDTO cliente, string dni)
        {
            bool guardado = false;
            ClienteImpl bd = new ClienteImpl();
            guardado = bd.actualizar(cliente, dni);
            return guardado;
        }

        public int ActualizarConUsuario(ClienteDTO cliente, string dni)
        {
            int codigoRetorno = 0;
            ClienteImpl bd = new ClienteImpl();
            codigoRetorno = bd.actualizarConUsuario(cliente, dni);
            return codigoRetorno;
        }

        public bool ActualizarPass(ClienteDTO cliente, string dni)
        {
            bool guardado = false;
            ClienteImpl bd = new ClienteImpl();
            guardado = bd.actualizarPass(cliente, dni);
            return guardado;
        }
    }
}
