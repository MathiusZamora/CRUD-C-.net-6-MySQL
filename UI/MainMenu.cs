using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form nextForm = new AdministracionClientes();
            nextForm.Show();
            //this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form nextForm = new AdministracionProductos();
            nextForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form nextForm = new AdministracionProveedores();
            nextForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suavetona mi shak, aun lo estamos desarrollando ");

        }

        private void MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }
}
