using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ciphertrust_app.Conexion;
using ciphertrust_app.Datos;
using ciphertrust_app.Model;

namespace ciphertrust_app
{
    public partial class PantallaClientes : Form

    {
        private int flag_operacion = 0;
        private string? flag_direccion = "";
        private string? flag_telefono = "";

        public PantallaClientes()
        {
            InitializeComponent();
            ReiniciarTabla();
        }

        private void ReiniciarTabla()
        {
            LlenarTabla();
            DesabilitarCampos();
            this.Shown += QuitarSeleccion;
            dataGridClientes.SelectionChanged += SeleccionarCliente;
        }

        private void SeleccionarCliente(object? sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count > 0)
            {
                string? dni = dataGridClientes.SelectedRows[0].Cells[4].Value?.ToString();

                if (!string.IsNullOrEmpty(dni))
                {
                    ClienteConexion clienteConexion = new ClienteConexion();
                    ClienteDTO? cliente = clienteConexion.obtenerPorDni(dni);

                    if (cliente != null)
                    {
                        txtUsuario.Text = cliente.user;
                        txtNombre.Text = dataGridClientes.SelectedRows[0].Cells[0].Value.ToString();
                        txtApellido.Text = dataGridClientes.SelectedRows[0].Cells[1].Value.ToString();
                        flag_direccion = dataGridClientes.SelectedRows[0].Cells[2].Value.ToString();
                        flag_telefono = dataGridClientes.SelectedRows[0].Cells[3].Value.ToString();
                        txtDireccion.Text = "******DATA ENCRIPTADA******";
                        txtTelefono.Text = "******DATA ENCRIPTADA******";
                        txtDNI.Text = dni;

                        HabilitarBotones();
                    }
                    else
                    {

                        MessageBox.Show("No se pudo obtener el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
        }

        private void HabilitarBotones()
        {
            if (dataGridClientes.Focused)
            {
                btnAsignarContraseña.Visible = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnDesencriptar.Enabled = true;
            }

        }

        private void QuitarSeleccion(object? sender, EventArgs e)
        {
            dataGridClientes.ClearSelection();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtDNI.Text = "";
        }

        private void DesabilitarCampos()
        {
            txtUsuario.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtDNI.Enabled = false;

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnDesencriptar.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            btnAgregar.Enabled = true;
            btnExportar.Enabled = true;

            btnAsignarContraseña.Visible = false;
        }

        private void LlenarTabla()
        {
            ClienteImpl clienteImpl = new ClienteImpl();
            List<ClienteDTO>? clientes = clienteImpl.obtenerTodos();

            if (clientes != null)
            {

                foreach (var cliente in clientes)
                {

                    dataGridClientes.Rows.Add(cliente.nombre, cliente.apellido, cliente.direccion, cliente.telefono, cliente.dni);

                }


            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            HabilitarCampos();
            desabilitarBotones();

            dataGridClientes.Enabled = false;
            flag_operacion = 1;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

        }

        private void desabilitarBotones()
        {

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnDesencriptar.Enabled = false;
            btnAsignarContraseña.Visible = false;
            btnAgregar.Enabled = false;
            btnExportar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtUsuario.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtDNI.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dataGridClientes.Enabled = true;
            DesabilitarCampos();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag_operacion == 1)
            {
                ClienteConexion clienteConexion = new ClienteConexion();

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string dni = txtDNI.Text;
                string user = txtUsuario.Text;

                ClienteDTO cliente = new ClienteDTO(nombre, apellido, direccion, telefono, dni, user);
                ClienteDTO clienteGuardado = clienteConexion.agregarConUsuario(cliente);

                if (clienteGuardado.direccion != null && clienteGuardado.telefono != null)
                {

                    if (!clienteGuardado.direccion.Equals(""))
                    {
                        MessageBox.Show("Cliente guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridClientes.Rows.Clear();
                        dataGridClientes.Enabled = true;
                        ReiniciarTabla();

                    }
                    else
                    {
                        MessageBox.Show("Error, Revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                }
                else
                {
                    MessageBox.Show("Error, No se pudo encriptar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



            }
            else if (flag_operacion == 2)
            {

                ClienteConexion clienteConexion = new ClienteConexion();
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string dni = txtDNI.Text;
                string user = txtUsuario.Text;
                ClienteDTO cliente = new ClienteDTO(nombre, apellido, direccion, telefono, dni, user);
                int respuesta = clienteConexion.ActualizarConUsuario(cliente, dni);

                switch (respuesta)
                {

                    case 1:
                        MessageBox.Show("Cliente modificado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridClientes.Rows.Clear();
                        dataGridClientes.Enabled = true;
                        ReiniciarTabla();
                        break;

                    case 2:
                        MessageBox.Show("Error,  no se pudo encriptar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 3:
                        MessageBox.Show("Error,  no se pudo encriptar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error,  no se pudo modificar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }

            }


        }

        private void btnModificar_Click(object sender, EventArgs e)

        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string? direccion = flag_direccion;
            string? telefono = flag_telefono;
            string dni = txtDNI.Text;

            ClienteDTO cliente = new ClienteDTO(nombre, apellido, direccion, telefono, dni);
            ClienteConexion clienteConexion = new ClienteConexion();

            ClienteDTO clienteDesencriptado = clienteConexion.desencriptar(cliente);

            txtDireccion.Text = clienteDesencriptado.direccion;
            txtTelefono.Text = clienteDesencriptado.telefono;

            HabilitarCampos();
            desabilitarBotones();

            dataGridClientes.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            flag_operacion = 2;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int confirmacion = (int)MessageBox.Show("¿Está seguro de eliminar el cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == 6)
            {
                string dni = txtDNI.Text;
                ClienteImpl bd = new ClienteImpl();

                if (bd.eliminar(dni))
                {
                    MessageBox.Show("Cliente eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridClientes.Rows.Clear();
                    ReiniciarTabla();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            ClienteConexion clienteConexion = new ClienteConexion();

            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Direccion = flag_direccion;
            string Telefono = flag_telefono;
            string Dni = txtDNI.Text;

            ClienteDTO cliente = new ClienteDTO(Nombre, Apellido, Direccion, Telefono, Dni);

            ClienteDTO newCliente = clienteConexion.desencriptar(cliente);

            txtDireccion.Text = newCliente.direccion;
            txtTelefono.Text = newCliente.telefono;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            //Aqui se quiere exportar los datos de la tabla en un archivo .txt

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string archivo = path + "\\Clientes.txt";

            Debug.WriteLine("ruta donde se va a guardar el archivo: " + archivo);

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo))
                {
                    file.WriteLine("Nombre,Apellido,Direccion,Telefono,DNI");
                    foreach (DataGridViewRow row in dataGridClientes.Rows)
                    {
                        file.WriteLine(row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() + "," + row.Cells[2].Value.ToString() + "," + row.Cells[3].Value.ToString() + "," + row.Cells[4].Value.ToString());
                    }
                    MessageBox.Show("Archivo exportado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, no se pudo exportar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
