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
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Icon = new Icon(errorProvider1.Icon, new Size(16, 16));
            if (validacion() == true)
            {
                FormularioMdi Formulario2 = new FormularioMdi();
                Formulario2.Show();
                this.Hide();
            }
        }
    }
}
