using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTOFINALPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtContra.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Icon = new Icon(errorProvider1.Icon, new Size(16, 16));
            if (validacion() == true)
            {
                Menu_Admin menuA = new Menu_Admin();
                menuA.Show();
                this.Hide();
            }
        }

        private void chbMirarContra_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMirarContra.Checked == true)
            {
                txtContra.UseSystemPasswordChar = false;
            }
            else
            {
                txtContra.UseSystemPasswordChar = true;
            }
        }
        private Boolean validacion()
        {
            Boolean validar = false;
            errorProvider1.Clear();

            if (txtUsuario.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsuario, "Campo Obligatorio");

            }
            else if (txtContra.Text == string.Empty)
            {
                errorProvider1.SetError(txtContra, "Campo Obligatorio");
            }
            else if ((txtUsuario.Text.Length >= 4) && (txtUsuario.Text.Length <= 8))
            {
                validar = true;
            }
            else
            {
                errorProvider1.SetError(txtUsuario, "Usuario Incorrecto");
                validar = false;
            }
            return validar;
        }
    }
}
