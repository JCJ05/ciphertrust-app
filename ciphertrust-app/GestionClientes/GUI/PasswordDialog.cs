using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ciphertrust_app
{
    public partial class PasswordDialog : Form
    {
       
        public PasswordDialog()
        {
            InitializeComponent();
        }

        private void btnCancelarContra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            string password1 = txtPass1.Text;
            string password2 = txtPass2.Text;

            if (String.IsNullOrEmpty(password1))
            {

                //Hacer un popup para decir que ingrese caracteres en la contraseña

                MessageBox.Show("Debe ingresar caracteres para poder cambiar la contraseña");

            }
            else {

                if (password1.Equals(password2))
                {
                    PantallaClientes pantallaClientes = new PantallaClientes();
                    pantallaClientes.setPass(password1);
                    this.Close();

                }
                else {

                    MessageBox.Show("Las contraseñas no coinciden");
                
                }
            
            }
        }
    }
}
