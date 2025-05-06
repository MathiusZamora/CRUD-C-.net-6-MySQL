using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace UI
{
    public partial class AdministracionProveedores : Form
    {
        private static int IdUsuarioSesion = 1;
        private static int IdRegistro = 0;
        public AdministracionProveedores()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
        }

        private void AdministracionProveedores_Load(object sender, EventArgs e)
        {
            cargarGrid();

        }


        private void cargarGrid()
        {
            try
            {
                //listo el orden de la entidad
                gridProveedores.DataSource = BLL_Proveedores.Lista();
                gridProveedores.Columns[0].HeaderText = "ID Proveedor";
                gridProveedores.Columns[1].HeaderText = "Nombre del Proveedor";
                gridProveedores.Columns[2].HeaderText = "Número";
                gridProveedores.Columns[3].HeaderText = "Correo";
                gridProveedores.Columns[4].HeaderText = "Direccion";
                gridProveedores.Columns[5].Visible = false;
                gridProveedores.Columns[6].Visible = false;
                gridProveedores.Columns[7].Visible = false;
                gridProveedores.Columns[8].Visible = false;
                gridProveedores.Columns[9].Visible = false;
                LimpiarCampos();

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombreProveedor.Text) || string.IsNullOrWhiteSpace(txtNombreProveedor.Text))
            {
                MessageBox.Show("Ingrese el nombre del Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtNombreProveedor.Text.Length > 200)
            {
                MessageBox.Show("El campo nombre del Proveedor debe ser menor a 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtNumeroProveedor.Text) || string.IsNullOrWhiteSpace(txtNumeroProveedor.Text))
            {
                MessageBox.Show("Ingrese el número del Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtNumeroProveedor.Text.Length < 8 || txtNumeroProveedor.Text.Length < 8)
            {
                MessageBox.Show("Ingrese un número de teléfono válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BLL_Proveedores.ValidarNumeroProv(txtNumeroProveedor.Text, IdRegistro))
            {
                MessageBox.Show("El número de teléfono ya se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreoProveedor.Text) || string.IsNullOrWhiteSpace(txtCorreoProveedor.Text))
            {
                MessageBox.Show("Ingrese el correo del Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!(txtCorreoProveedor.Text.Length < 200))
            {
                MessageBox.Show("El campo correo debe ser menor a 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.ValidateEmail(txtCorreoProveedor.Text))
            {
                MessageBox.Show("Ingrese un correo válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BLL_Proveedores.ValidarCorreoProv(txtCorreoProveedor.Text, IdRegistro))
            {
                MessageBox.Show("El Correo ya se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccionProveedor.Text) || string.IsNullOrWhiteSpace(txtDireccionProveedor.Text))
            {
                MessageBox.Show("Ingrese la direccion del Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Guardar()
        {
            if (validarFormulario())
            {
                Proveedores Entidad = new Proveedores();
                Entidad.NombreProveedor = txtNombreProveedor.Text;
                Entidad.Numero = txtNumeroProveedor.Text;
                Entidad.Correo = txtCorreoProveedor.Text;
                Entidad.Direccion = txtDireccionProveedor.Text;

                if (IdRegistro > 0)
                {
                    //Actualizar
                    Entidad.IdProveedor = IdRegistro;
                    Entidad.IdUsuarioActualiza = IdUsuarioSesion;
                    if (BLL_Proveedores.Update(Entidad))
                    {
                        MessageBox.Show("Registro actualizado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrid();
                        return;
                    }
                    MessageBox.Show("El Registro no fue actualizado con exito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Insertar          
                Entidad.IdUsuarioRegistra = IdUsuarioSesion;
                if (BLL_Proveedores.Insert(Entidad).IdProveedor > 0)
                {
                    MessageBox.Show("Registro agregado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrid();
                    return;
                }
                MessageBox.Show("El Registro no fue agregado con exito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void Anular()
        {
            try
            {
                Proveedores entidad = new();
                entidad.IdProveedor = IdRegistro;
                entidad.IdUsuarioActualiza = IdUsuarioSesion;
                if (BLL_Proveedores.Anular(entidad))
                {
                    MessageBox.Show("Registro anulado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrid();
                    return;
                }
                MessageBox.Show("El Registro no fue anulado con exito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }
        private void cargarCampos()
        {
            try
            {
                IdRegistro = Convert.ToInt32(gridProveedores.CurrentRow.Cells[0].Value);
                txtNombreProveedor.Text = gridProveedores.CurrentRow.Cells[1].Value.ToString();
                txtNumeroProveedor.Text = gridProveedores.CurrentRow.Cells[2].Value.ToString();
                txtCorreoProveedor.Text = gridProveedores.CurrentRow.Cells[3].Value.ToString();
                txtDireccionProveedor.Text = gridProveedores.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            IdRegistro = 0;
            txtNombreProveedor.Text = string.Empty;
            txtNumeroProveedor.Text = string.Empty;
            txtCorreoProveedor.Text = string.Empty;
            txtDireccionProveedor.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void gridProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarCampos();
        }
    }
}
