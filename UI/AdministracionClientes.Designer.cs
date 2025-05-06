namespace UI
{
    partial class AdministracionClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministracionClientes));
            label1 = new Label();
            txtNombreCliente = new TextBox();
            txtNumeroTelefono = new TextBox();
            label2 = new Label();
            txtCorreo = new TextBox();
            label3 = new Label();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnAnular = new Button();
            label4 = new Label();
            gridClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Cliente";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(12, 47);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(426, 23);
            txtNombreCliente.TabIndex = 1;
            // 
            // txtNumeroTelefono
            // 
            txtNumeroTelefono.Location = new Point(12, 103);
            txtNumeroTelefono.Name = "txtNumeroTelefono";
            txtNumeroTelefono.Size = new Size(426, 23);
            txtNumeroTelefono.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 2;
            label2.Text = "Numero de telefono";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 162);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(426, 23);
            txtCorreo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 144);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "Correo";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(35, 228);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(162, 228);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnAnular
            // 
            btnAnular.Location = new Point(294, 228);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(75, 23);
            btnAnular.TabIndex = 8;
            btnAnular.Text = "Anular";
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 267);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 9;
            label4.Text = "Listado de Clientes";
            // 
            // gridClientes
            // 
            gridClientes.AllowUserToAddRows = false;
            gridClientes.AllowUserToDeleteRows = false;
            gridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridClientes.Location = new Point(12, 288);
            gridClientes.MultiSelect = false;
            gridClientes.Name = "gridClientes";
            gridClientes.RowHeadersVisible = false;
            gridClientes.RowTemplate.Height = 25;
            gridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridClientes.Size = new Size(426, 186);
            gridClientes.TabIndex = 10;
            gridClientes.CellClick += gridClientes_CellClick;
            // 
            // AdministracionClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(450, 486);
            Controls.Add(gridClientes);
            Controls.Add(label4);
            Controls.Add(btnAnular);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtCorreo);
            Controls.Add(label3);
            Controls.Add(txtNumeroTelefono);
            Controls.Add(label2);
            Controls.Add(txtNombreCliente);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdministracionClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdministracionClientes";
            Load += AdministracionClientes_Load;
            ((System.ComponentModel.ISupportInitialize)gridClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreCliente;
        private TextBox txtNumeroTelefono;
        private Label label2;
        private TextBox txtCorreo;
        private Label label3;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnAnular;
        private Label label4;
        private DataGridView gridClientes;
    }
}