namespace UI
{
    partial class AdministracionProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministracionProveedores));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNombreProveedor = new TextBox();
            txtNumeroProveedor = new TextBox();
            txtCorreoProveedor = new TextBox();
            txtDireccionProveedor = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            gridProveedores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridProveedores).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Numero:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 119);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Correo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 168);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 3;
            label4.Text = "Direccion:";
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(12, 27);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(373, 23);
            txtNombreProveedor.TabIndex = 4;
            // 
            // txtNumeroProveedor
            // 
            txtNumeroProveedor.Location = new Point(12, 85);
            txtNumeroProveedor.Name = "txtNumeroProveedor";
            txtNumeroProveedor.Size = new Size(165, 23);
            txtNumeroProveedor.TabIndex = 5;
            // 
            // txtCorreoProveedor
            // 
            txtCorreoProveedor.Location = new Point(12, 137);
            txtCorreoProveedor.Name = "txtCorreoProveedor";
            txtCorreoProveedor.Size = new Size(321, 23);
            txtCorreoProveedor.TabIndex = 6;
            // 
            // txtDireccionProveedor
            // 
            txtDireccionProveedor.Location = new Point(12, 186);
            txtDireccionProveedor.Name = "txtDireccionProveedor";
            txtDireccionProveedor.Size = new Size(321, 23);
            txtDireccionProveedor.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(12, 245);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(258, 245);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Anular";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(137, 245);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Guardar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // gridProveedores
            // 
            gridProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProveedores.Location = new Point(12, 288);
            gridProveedores.Name = "gridProveedores";
            gridProveedores.RowTemplate.Height = 25;
            gridProveedores.Size = new Size(388, 206);
            gridProveedores.TabIndex = 11;
            gridProveedores.CellClick += gridProveedores_CellClick;
            // 
            // AdministracionProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 506);
            Controls.Add(gridProveedores);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtDireccionProveedor);
            Controls.Add(txtCorreoProveedor);
            Controls.Add(txtNumeroProveedor);
            Controls.Add(txtNombreProveedor);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdministracionProveedores";
            Text = "AdministracionProveedores";
            Load += AdministracionProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)gridProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNombreProveedor;
        private TextBox txtNumeroProveedor;
        private TextBox txtCorreoProveedor;
        private TextBox txtDireccionProveedor;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView gridProveedores;
    }
}