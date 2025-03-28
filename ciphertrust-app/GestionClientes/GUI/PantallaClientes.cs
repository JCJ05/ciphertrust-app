﻿using System;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ciphertrust_app
{
    public partial class PantallaClientes : Form

    {
        private int flag_operacion = 0;
        private string? flag_direccion = "";
        private string? flag_telefono = "";
        private string? flag_dni = "";

        public PantallaClientes()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(((Bitmap)GestionClientes.GestionClientes.ICON).GetHicon());
            ReiniciarTabla();
        }

        private void ReiniciarTabla()
        {
            LlenarTabla();
            DesabilitarCampos();
            this.Shown += QuitarSeleccion;
            dataGridClientes.SelectionChanged += SeleccionarCliente;
        }

        public void setPass(string data, string dni)
        {

            ClienteConexion clienteConexion = new ClienteConexion();
            ClienteDTO clienteModificado;
            bool rsptaM = false;

            string NombreM = txtNombre.Text;
            string ApellidoM = txtApellido.Text;
            string DireccionM = txtDireccion.Text;
            string TelefonoM = txtTelefono.Text;
            string DniM = txtDNI.Text;
            string UserM = txtUsuario.Text;
            string PassM = data;

            Debug.WriteLine(DniM);

            clienteModificado = new ClienteDTO(NombreM, ApellidoM, DireccionM, TelefonoM, DniM, UserM, PassM);
            rsptaM = clienteConexion.ActualizarPass(clienteModificado, dni);

            if (rsptaM)
            {
                MessageBox.Show("Actualización de contraseña exitosa");
            }
            else
            {
                MessageBox.Show("Error, Revise los campos");
            }
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

                    flag_dni = dni;

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
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string dni = txtDNI.Text;
            string user = txtUsuario.Text;

            if (System.String.IsNullOrEmpty(nombre) || System.String.IsNullOrEmpty(apellido)
               || System.String.IsNullOrEmpty(direccion) || System.String.IsNullOrEmpty(telefono)
               || System.String.IsNullOrEmpty(dni) || System.String.IsNullOrEmpty(user))
            {

                MessageBox.Show("Error, hay datos que estan vacio por favor completarlos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (flag_operacion == 1)
                {
                    ClienteConexion clienteConexion = new ClienteConexion();



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
            string archivo = path + "\\ClientesListado.txt";

            Debug.WriteLine("ruta donde se va a guardar el archivo: " + archivo);

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo))
                {
                    file.WriteLine("Nombre,Apellido,Direccion,Telefono,DNI");
                    foreach (DataGridViewRow row in dataGridClientes.Rows)
                    {
                        ClienteConexion clienteConexion = new ClienteConexion();

                        string Nombre = row.Cells[0].Value.ToString();
                        string Apellido = row.Cells[1].Value.ToString();
                        string Direccion = row.Cells[2].Value.ToString();
                        string Telefono = row.Cells[3].Value.ToString();
                        string Dni = row.Cells[4].Value.ToString();

                        ClienteDTO cliente = new ClienteDTO(Nombre, Apellido, Direccion, Telefono, Dni);
                        ClienteDTO newCliente = clienteConexion.desencriptar(cliente);

                        file.WriteLine(Nombre + "," + Apellido + "," + newCliente.direccion + "," + newCliente.telefono + "," + Dni);
                    }
                    MessageBox.Show("Archivo exportado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, no se pudo exportar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAsignarContraseña_Click(object sender, EventArgs e)
        {
            PasswordDialog dlg = new PasswordDialog(flag_dni);
            dlg.ShowDialog();

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtTelefono.Text.Length >= 9)
            {

                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                else
                {

                    e.Handled = true;
                }

            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtDNI.Text.Length >= 8)
            {

                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                else
                {

                    e.Handled = true;
                }

            }

        }

        private void PantallaClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro que quieres salir?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {

                    Application.Exit();
                }

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre
                }
            }
            else {

                Application.Exit();
            }
        }
    }
}
