using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

        public PantallaClientes()
        {
            InitializeComponent();
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
                        txtDireccion.Text = dataGridClientes.SelectedRows[0].Cells[2].Value.ToString();
                        txtTelefono.Text = dataGridClientes.SelectedRows[0].Cells[3].Value.ToString();
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
    }
}
