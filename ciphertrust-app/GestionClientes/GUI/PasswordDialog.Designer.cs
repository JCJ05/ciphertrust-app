namespace ciphertrust_app
{
    partial class PasswordDialog
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
            label1 = new Label();
            label2 = new Label();
            txtPass1 = new TextBox();
            label3 = new Label();
            txtPass2 = new TextBox();
            btnGuardarContra = new Button();
            btnCancelarContra = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(34, 59);
            label1.Name = "label1";
            label1.Size = new Size(368, 54);
            label1.TabIndex = 0;
            label1.Text = "Asignar Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 159);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // txtPass1
            // 
            txtPass1.Location = new Point(247, 156);
            txtPass1.Name = "txtPass1";
            txtPass1.Size = new Size(219, 27);
            txtPass1.TabIndex = 2;
            txtPass1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 226);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 3;
            label3.Text = "Repite la contraseña";
            // 
            // txtPass2
            // 
            txtPass2.Location = new Point(247, 223);
            txtPass2.Name = "txtPass2";
            txtPass2.Size = new Size(219, 27);
            txtPass2.TabIndex = 4;
            txtPass2.UseSystemPasswordChar = true;
            // 
            // btnGuardarContra
            // 
            btnGuardarContra.Location = new Point(132, 307);
            btnGuardarContra.Name = "btnGuardarContra";
            btnGuardarContra.Size = new Size(114, 39);
            btnGuardarContra.TabIndex = 5;
            btnGuardarContra.Text = "Guardar";
            btnGuardarContra.UseVisualStyleBackColor = true;
            btnGuardarContra.Click += btnGuardarContra_Click;
            // 
            // btnCancelarContra
            // 
            btnCancelarContra.Location = new Point(299, 307);
            btnCancelarContra.Name = "btnCancelarContra";
            btnCancelarContra.Size = new Size(114, 39);
            btnCancelarContra.TabIndex = 6;
            btnCancelarContra.Text = "Cancelar";
            btnCancelarContra.UseVisualStyleBackColor = true;
            btnCancelarContra.Click += btnCancelarContra_Click;
            // 
            // PasswordDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 414);
            Controls.Add(btnCancelarContra);
            Controls.Add(btnGuardarContra);
            Controls.Add(txtPass2);
            Controls.Add(label3);
            Controls.Add(txtPass1);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "PasswordDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PasswordDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPass1;
        private Label label3;
        private TextBox txtPass2;
        private Button btnGuardarContra;
        private Button btnCancelarContra;
    }
}