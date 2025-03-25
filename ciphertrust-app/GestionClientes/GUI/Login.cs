using ciphertrust_app.Conexion;
using ciphertrust_app.Model;

namespace ciphertrust_app
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {

            ClienteConexion clienteConexion = new ClienteConexion();

            string user = txtBoxUser.Text;
            string pass = txtBoxPass.Text;

            ClienteDTO? clienteDTO = clienteConexion.iniciarSesion(user, pass);

            if (clienteDTO != null)
            {

                PantallaClientes pantallaClientes = new PantallaClientes();
                pantallaClientes.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");

            }


        }

        private void txtBoxPass_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) {

                ClienteConexion clienteConexion = new ClienteConexion();

                string user = txtBoxUser.Text;
                string pass = txtBoxPass.Text;

                ClienteDTO? clienteDTO = clienteConexion.iniciarSesion(user, pass);

                if (clienteDTO != null)
                {

                    PantallaClientes pantallaClientes = new PantallaClientes();
                    pantallaClientes.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");

                }



            }

        }
    }
}
