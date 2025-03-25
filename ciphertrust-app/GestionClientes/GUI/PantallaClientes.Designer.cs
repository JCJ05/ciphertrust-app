namespace ciphertrust_app
{
    partial class PantallaClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaClientes));
            dataGridClientes = new DataGridView();
            ColumnNombre = new DataGridViewTextBoxColumn();
            ColumnApellido = new DataGridViewTextBoxColumn();
            ColumnDireccion = new DataGridViewTextBoxColumn();
            ColumnTelefono = new DataGridViewTextBoxColumn();
            ColumnDNI = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            panel2 = new Panel();
            btnExportar = new Button();
            btnDesencriptar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtDNI = new TextBox();
            label6 = new Label();
            txtTelefono = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label4 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtUsuario = new TextBox();
            label1 = new Label();
            btnAsignarContraseña = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridClientes
            // 
            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Columns.AddRange(new DataGridViewColumn[] { ColumnNombre, ColumnApellido, ColumnDireccion, ColumnTelefono, ColumnDNI });
            dataGridClientes.Location = new Point(12, 32);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.ReadOnly = true;
            dataGridClientes.RowHeadersVisible = false;
            dataGridClientes.RowHeadersWidth = 51;
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClientes.Size = new Size(955, 396);
            dataGridClientes.TabIndex = 0;
            // 
            // ColumnNombre
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnNombre.DefaultCellStyle = dataGridViewCellStyle1;
            ColumnNombre.HeaderText = "Nombre";
            ColumnNombre.MinimumWidth = 6;
            ColumnNombre.Name = "ColumnNombre";
            ColumnNombre.ReadOnly = true;
            ColumnNombre.Width = 150;
            // 
            // ColumnApellido
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnApellido.DefaultCellStyle = dataGridViewCellStyle2;
            ColumnApellido.HeaderText = "Apellido";
            ColumnApellido.MinimumWidth = 6;
            ColumnApellido.Name = "ColumnApellido";
            ColumnApellido.ReadOnly = true;
            ColumnApellido.Width = 150;
            // 
            // ColumnDireccion
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDireccion.DefaultCellStyle = dataGridViewCellStyle3;
            ColumnDireccion.HeaderText = "Direccion";
            ColumnDireccion.MinimumWidth = 6;
            ColumnDireccion.Name = "ColumnDireccion";
            ColumnDireccion.ReadOnly = true;
            ColumnDireccion.Width = 250;
            // 
            // ColumnTelefono
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTelefono.DefaultCellStyle = dataGridViewCellStyle4;
            ColumnTelefono.HeaderText = "Telefono";
            ColumnTelefono.MinimumWidth = 6;
            ColumnTelefono.Name = "ColumnTelefono";
            ColumnTelefono.ReadOnly = true;
            ColumnTelefono.Width = 250;
            // 
            // ColumnDNI
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDNI.DefaultCellStyle = dataGridViewCellStyle5;
            ColumnDNI.HeaderText = "Dni";
            ColumnDNI.MinimumWidth = 6;
            ColumnDNI.Name = "ColumnDNI";
            ColumnDNI.ReadOnly = true;
            ColumnDNI.Width = 150;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(txtDNI);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtDireccion);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtApellido);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAsignarContraseña);
            panel1.Location = new Point(1026, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 727);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnExportar);
            panel2.Controls.Add(btnDesencriptar);
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnAgregar);
            panel2.Location = new Point(3, 599);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 125);
            panel2.TabIndex = 15;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(240, 73);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(123, 38);
            btnExportar.TabIndex = 4;
            btnExportar.Text = "Exportar datos";
            btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnDesencriptar
            // 
            btnDesencriptar.Location = new Point(92, 73);
            btnDesencriptar.Name = "btnDesencriptar";
            btnDesencriptar.Size = new Size(106, 38);
            btnDesencriptar.TabIndex = 3;
            btnDesencriptar.Text = "Desencriptar";
            btnDesencriptar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(291, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 38);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(159, 20);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(106, 38);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(19, 20);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 38);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.Location = new Point(68, 473);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 76);
            btnGuardar.TabIndex = 14;
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(243, 473);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 76);
            btnCancelar.TabIndex = 13;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(162, 406);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(195, 27);
            txtDNI.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(34, 405);
            label6.Name = "label6";
            label6.Size = new Size(46, 28);
            label6.TabIndex = 11;
            label6.Text = "DNI";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(162, 345);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(195, 27);
            txtTelefono.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(34, 344);
            label5.Name = "label5";
            label5.Size = new Size(86, 28);
            label5.TabIndex = 9;
            label5.Text = "Telefono";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(162, 285);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(195, 27);
            txtDireccion.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(34, 281);
            label4.Name = "label4";
            label4.Size = new Size(94, 28);
            label4.TabIndex = 7;
            label4.Text = "Direccion";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(162, 222);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(195, 27);
            txtApellido.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(34, 218);
            label3.Name = "label3";
            label3.Size = new Size(86, 28);
            label3.TabIndex = 5;
            label3.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(162, 161);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(195, 27);
            txtNombre.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(34, 157);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(162, 102);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(195, 27);
            txtUsuario.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(34, 98);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 1;
            label1.Text = "Usuario";
            // 
            // btnAsignarContraseña
            // 
            btnAsignarContraseña.Location = new Point(22, 28);
            btnAsignarContraseña.Name = "btnAsignarContraseña";
            btnAsignarContraseña.Size = new Size(188, 39);
            btnAsignarContraseña.TabIndex = 0;
            btnAsignarContraseña.Text = "Asignar Contraseña";
            btnAsignarContraseña.UseVisualStyleBackColor = true;
            // 
            // PantallaClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1441, 751);
            Controls.Add(panel1);
            Controls.Add(dataGridClientes);
            Name = "PantallaClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PantallaClientes";
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnNombre;
        private DataGridViewTextBoxColumn ColumnApellido;
        private DataGridViewTextBoxColumn ColumnDireccion;
        private DataGridViewTextBoxColumn ColumnTelefono;
        private DataGridViewTextBoxColumn ColumnDNI;
        private DataGridView dataGridClientes;
        private Panel panel1;
        private Button btnAsignarContraseña;
        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtUsuario;
        private Label label3;
        private TextBox txtTelefono;
        private Label label5;
        private TextBox txtDireccion;
        private Label label4;
        private TextBox txtApellido;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtDNI;
        private Label label6;
        private Panel panel2;
        private Button btnAgregar;
        private Button btnExportar;
        private Button btnDesencriptar;
        private Button btnEliminar;
        private Button btnModificar;
    }
}