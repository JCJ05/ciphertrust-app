namespace ciphertrust_app
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnIngresar = new Button();
            txtBoxPass = new TextBox();
            txtBoxUser = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(2, 313);
            panel1.Name = "panel1";
            panel1.Size = new Size(617, 130);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(593, 118);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(btnIngresar);
            panel2.Controls.Add(txtBoxPass);
            panel2.Controls.Add(txtBoxUser);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(128, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(358, 321);
            panel2.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(79, 265);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(211, 41);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtBoxPass
            // 
            txtBoxPass.Location = new Point(173, 212);
            txtBoxPass.Name = "txtBoxPass";
            txtBoxPass.Size = new Size(172, 27);
            txtBoxPass.TabIndex = 5;
            txtBoxPass.UseSystemPasswordChar = true;
            txtBoxPass.KeyDown += txtBoxPass_KeyDown;
            // 
            // txtBoxUser
            // 
            txtBoxUser.Location = new Point(173, 151);
            txtBoxUser.Name = "txtBoxUser";
            txtBoxUser.Size = new Size(172, 27);
            txtBoxUser.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.WindowFrame;
            label3.Font = new Font("Segoe UI", 18F);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(3, 198);
            label3.Name = "label3";
            label3.Size = new Size(175, 41);
            label3.TabIndex = 3;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(3, 137);
            label2.Name = "label2";
            label2.Size = new Size(134, 41);
            label2.TabIndex = 2;
            label2.Text = "Usuario: ";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(152, 73);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 62);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(46, 8);
            label1.Name = "label1";
            label1.Size = new Size(279, 62);
            label1.TabIndex = 0;
            label1.Text = "Bienvenidos\r\n";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(599, 452);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(int.MaxValue, int.MaxValue);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox2;
        private TextBox txtBoxPass;
        private TextBox txtBoxUser;
        private Label label3;
        private Label label2;
        private Button btnIngresar;
    }
}
