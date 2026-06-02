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
    public partial class FormularioAlumnos : Form
    {
        public FormularioAlumnos()
        {
            InitializeComponent();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            Alumons alumnos = new Alumons();
            alumnos.Show();
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            Asitencia asis = new Asitencia();
            asis.Show();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            ControlNotas notas = new ControlNotas();
            notas.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
