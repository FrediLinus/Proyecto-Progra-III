using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PROYECTOFINALPOO.Admin;


namespace PROYECTOFINALPOO
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }
        private int indiceSeleccionado = -1;
        private void Inventario_Load(object sender, EventArgs e)
        {


            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;

            CargarInventario();


        }

        private void CargarInventario()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosSistema.Inventario;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;
            }
        }

        private void btnIngresarB_Click(object sender, EventArgs e)
        {
            CargarInventario();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este uniforme del inventario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                DatosSistema.Inventario.RemoveAt(indiceSeleccionado);

                CargarInventario();

                indiceSeleccionado = -1;

                MessageBox.Show("Registro eliminado correctamente.");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu_Admin menu = new Menu_Admin();
            menu.Show();
            this.Hide();
        }
    }
        
    }

