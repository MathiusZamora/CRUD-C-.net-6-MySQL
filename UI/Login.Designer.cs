namespace UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            btnLogin = new Button();
            btnClose = new PictureBox();
            btnMinimize = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimize).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 122, 204);
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 330);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(50, 87);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(161, 142);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // txtUser
            // 
            txtUser.BackColor = SystemColors.ActiveBorder;
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.ForeColor = Color.DimGray;
            txtUser.Location = new Point(342, 69);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(376, 20);
            txtUser.TabIndex = 1;
            txtUser.Text = "Usuario";
            txtUser.Enter += txtUser_Enter;
            txtUser.Leave += txtUser_Leave;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ActiveBorder;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(344, 134);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(376, 20);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Contraseña";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(482, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 33);
            label1.TabIndex = 3;
            label1.Text = "LOGIN";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(40, 40, 40);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.LightGray;
            btnLogin.Location = new Point(344, 220);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 40);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Acceder";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClose
            // 
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(752, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 22);
            btnClose.SizeMode = PictureBoxSizeMode.Zoom;
            btnClose.TabIndex = 5;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Image = (Image)resources.GetObject("btnMinimize.Image");
            btnMinimize.Location = new Point(721, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(25, 22);
            btnMinimize.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimize.TabIndex = 6;
            btnMinimize.TabStop = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(780, 330);
            Controls.Add(btnMinimize);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            MouseDown += Login_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Label label1;
        private Button btnLogin;
        private PictureBox btnClose;
        private PictureBox pictureBox3;
        private PictureBox btnMinimize;
    }
}