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
    public partial class Ingreso_de_Uniformes : Form
    {
        public Ingreso_de_Uniformes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        // variable para modificar 
        private int indiceSeleccionado = -1;
        private void Ingreso_de_Uniformes_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
        }

        private void btnIngresarB_Click(object sender, EventArgs e)
        {
            Admin nuevo = new Admin();

            nuevo.Codigo = txtCodigo.Text;
            nuevo.Proveedor = txtNomProv.Text;
            nuevo.TipoSueter = cmbTipo.Text;
            nuevo.Talla = cmbTalla.Text;
            nuevo.Stock = Convert.ToInt32(npCantidad.Value);
            nuevo.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
            nuevo.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

            DatosSistema.Inventario.Add(nuevo);
            CargarDatos();

            MessageBox.Show("Uniforme agregado");
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosSistema.Inventario;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;

                txtCodigo.Text = DatosSistema.Inventario[e.RowIndex].Codigo;
                txtNomProv.Text = DatosSistema.Inventario[e.RowIndex].Proveedor;
                cmbTipo.Text = DatosSistema.Inventario[e.RowIndex].TipoSueter;
                cmbTalla.Text = DatosSistema.Inventario[e.RowIndex].Talla;
                npCantidad.Value = DatosSistema.Inventario[e.RowIndex].Stock;
                txtPrecioCompra.Text =
                    DatosSistema.Inventario[e.RowIndex].PrecioCompra.ToString();

                txtPrecioVenta.Text =
                    DatosSistema.Inventario[e.RowIndex].PrecioVenta.ToString();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            DatosSistema.Inventario[indiceSeleccionado].Codigo =
                txtCodigo.Text;

            DatosSistema.Inventario[indiceSeleccionado].Proveedor =
               txtNomProv.Text;

            DatosSistema.Inventario[indiceSeleccionado].TipoSueter =
                cmbTipo.Text;

            DatosSistema.Inventario[indiceSeleccionado].Talla =
                cmbTalla.Text;

            DatosSistema.Inventario[indiceSeleccionado].Stock =
                (int)npCantidad.Value;

            DatosSistema.Inventario[indiceSeleccionado].PrecioCompra =
                Convert.ToDecimal(txtPrecioCompra.Text);

            DatosSistema.Inventario[indiceSeleccionado].PrecioVenta =
                Convert.ToDecimal(txtPrecioVenta.Text);

            CargarDatos();

            MessageBox.Show("Registro modificado correctamente.");

            indiceSeleccionado = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este uniforme?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                DatosSistema.Inventario.RemoveAt(indiceSeleccionado);

                CargarDatos();

                indiceSeleccionado = -1;

                MessageBox.Show("Registro eliminado correctamente.");
            }
        }
    }
    }

