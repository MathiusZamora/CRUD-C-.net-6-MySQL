using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EL;
using BLL;  
using Utility;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

// formulario AdministracionClientes listo
namespace UI
{
    public partial class AdministracionClientes : Form
    {
        private static int IdUsuarioSesion = 1;
        private static int IdRegistro = 0;
        public AdministracionClientes()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
        }

        private void AdministracionClientes_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }


        #region metodos y funciones

        private void cargarGrid()
        {
            try
            {
                //listo el orden de la entidad
                gridClientes.DataSource = BLL_Clientes.Lista();
                gridClientes.Columns[0].Visible = false;
                gridClientes.Columns[1].HeaderText = "Nombre del Cliente";
                gridClientes.Columns[2].HeaderText = "Número";
                gridClientes.Columns[4].Visible = false;
                gridClientes.Columns[5].Visible = false;
                gridClientes.Columns[6].Visible = false;
                gridClientes.Columns[7].Visible = false;
                gridClientes.Columns[8].Visible = false;
                LimpiarCampos();

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtNombreCliente.Text.Length > 200)
            {
                MessageBox.Show("El campo nombre del cliente debe ser menor a 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtNumeroTelefono.Text) || string.IsNullOrWhiteSpace(txtNumeroTelefono.Text))
            {
                MessageBox.Show("Ingrese el número del cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtNumeroTelefono.Text.Length < 8 || txtNumeroTelefono.Text.Length > 8)
            {
                MessageBox.Show("Ingrese un número de teléfono válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BLL_Clientes.ValidarNumero(txtNumeroTelefono.Text, IdRegistro))
            {
                MessageBox.Show("El número de teléfono ya se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el correo del cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!(txtCorreo.Text.Length < 200))
            {
                MessageBox.Show("El campo correo debe ser menor a 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.ValidateEmail(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BLL_Clientes.ValidarCorreo(txtCorreo.Text, IdRegistro))
            {
                MessageBox.Show("El Correo ya se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Guardar()
        {
            if (validarFormulario())
            {
                Clientes Entidad = new Clientes();
                Entidad.NombreCliente  = txtNombreCliente.Text;
                Entidad.Numero = txtNumeroTelefono.Text;
                Entidad.Correo = txtCorreo.Text;

                if (IdRegistro > 0)
                {
                    //Actualizar
                    Entidad.IdCliente = IdRegistro;
                    Entidad.IdUsuarioActualiza = IdUsuarioSesion;
                    if (BLL_Clientes.Update(Entidad))
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
                if (BLL_Clientes.Insert(Entidad).IdCliente > 0)
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
                Clientes entidad = new();
                entidad.IdCliente = IdRegistro;
                entidad.IdUsuarioActualiza = IdUsuarioSesion;
                if (BLL_Clientes.Anular(entidad))
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
                IdRegistro = Convert.ToInt32(gridClientes.CurrentRow.Cells[0].Value);
                txtNombreCliente.Text = gridClientes.CurrentRow.Cells[1].Value.ToString();
                txtNumeroTelefono.Text = gridClientes.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = gridClientes.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            IdRegistro = 0;
            txtNombreCliente.Text = string.Empty;
            txtNumeroTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        #endregion

        #region Eventos de los controles

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }
        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarCampos();
        }

        #endregion







    }
}
