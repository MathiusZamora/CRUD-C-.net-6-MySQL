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
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;



namespace UI
{
    public partial class AdministracionProductos : Form
    {
        private static int IdUsuarioSesion = 1;
        private static int IdRegistro = 0;
        public AdministracionProductos()
        {
            InitializeComponent();
            CargarProveedoresCM();
            LimpiarCampos();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
        }


        private void AdministracionProductos_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarGrid()
        {
            try
            {
                // Obtén la lista de productos con los datos de los proveedores
                var listaProductos = BLL_Productos.ListaConProveedor(); // Llama al método de BLL

                // Si la lista tiene productos
                if (listaProductos != null && listaProductos.Count > 0)
                {
                    // Asignar la lista de productos al DataGridView
                    GridProductos.DataSource = listaProductos;

                    // Ocultar las columnas que no deseas mostrar
                    GridProductos.Columns[0].Visible = false; // IdProducto (si no lo quieres mostrar)
                    GridProductos.Columns[3].Visible = false; // IdProveedor (si no lo quieres mostrar)

                    // Cambiar los encabezados de las columnas para que tengan sentido
                    GridProductos.Columns[1].HeaderText = "Descripción del producto"; // Descripción
                    GridProductos.Columns[2].HeaderText = "Cantidad"; // Cantidad
                    GridProductos.Columns[4].HeaderText = "Proveedor"; // NombreProveedor (el que se muestra en el grid)

                    // Si es necesario, puedes ajustar el tamaño de las columnas
                    GridProductos.AutoResizeColumns();
                }
                else
                {
                    // Si no hay productos, mostrar un mensaje
                    MessageBox.Show("No se encontraron productos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Error)
            {
                // En caso de error, mostrar el mensaje
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtProducto.Text) || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Ingrese la descripción del producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtProducto.Text.Length > 200)
            {
                MessageBox.Show("El campo descripción del producto debe ser menor a 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese Cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtCantidad.Text.Length > 7 || txtCantidad.Text.Length > 7)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BLL_Productos.ValidarDescripcionProduct(txtProducto.Text, IdRegistro))
            {
                MessageBox.Show("Ya se encuentra un producto registrado con la misma descripción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Guardar()
        {
            if (validarFormulario())
            {

                Productos Entidad = new Productos();
                Entidad.Descripcion = txtProducto.Text;
                Entidad.Cantidad = txtCantidad.Text;
                Entidad.IdProveedor = Convert.ToInt32(comboBox1.SelectedValue);
                //Entidad.IdProveedor = idProveedor; // Asignamos el ID del proveedor

                if (IdRegistro > 0)
                {
                    //Actualizar
                    Entidad.IdProducto = IdRegistro;
                    Entidad.IdUsuarioActualiza = IdUsuarioSesion;
                    if (BLL_Productos.Update(Entidad))
                    {
                        MessageBox.Show("Registro actualizado con exito", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrid();
                        return;
                    }
                    MessageBox.Show("El Registro no fue actualizado con exito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Insertar          
                Entidad.IdUsuarioRegistra = IdUsuarioSesion;
                if (BLL_Productos.Insert(Entidad).IdProducto > 0)
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
                // Verificar si hay un registro válido para anular
                if (IdRegistro <= 0)
                {
                    MessageBox.Show("Seleccione un producto válido para anular.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Productos entidad = new();
                entidad.IdProducto = IdRegistro;
                entidad.IdUsuarioActualiza = IdUsuarioSesion;

                // Llamada al método de anulación
                if (BLL_Productos.Anular(entidad))
                {
                    MessageBox.Show("Registro anulado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrid();
                }
                else
                {
                    MessageBox.Show("El Registro no fue anulado con éxito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Error)
            {
                // Mostrar mensaje de error si ocurre una excepción
                MessageBox.Show($"Error: {Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargarCampos()
        {
            try
            {
                if (GridProductos.CurrentRow == null)
                {
                    MessageBox.Show("No hay ningún registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargar los datos de las celdas directamente
                IdRegistro = Convert.ToInt32(GridProductos.CurrentRow.Cells[0].Value);
                txtProducto.Text = GridProductos.CurrentRow.Cells[1].Value.ToString();
                txtCantidad.Text = GridProductos.CurrentRow.Cells[2].Value.ToString();

                // Cargar el ID del proveedor (suponiendo que es la columna 3)
                comboBox1.SelectedValue = GridProductos.CurrentRow.Cells[3].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedoresCM()
        {
            try
            {
                List<Proveedores> listaProveedores = BLL_Proveedores.Lista();
                comboBox1.DataSource = listaProveedores;
                comboBox1.DisplayMember = "NombreProveedor";
                comboBox1.ValueMember = "IdProveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Proveedores" + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            IdRegistro = 0;
            txtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            comboBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void GridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarCampos();
        }
    }
}
