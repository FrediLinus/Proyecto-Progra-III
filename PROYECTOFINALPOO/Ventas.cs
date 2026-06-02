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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
        }
        private int indiceSeleccionado = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;

                cmbTipoV.Text =
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                cmbTallaV.Text =
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                npCantidadV.Value =
                    Convert.ToDecimal(
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            }

            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;
            }
        }

        private void cmbTallaV_SelectedIndexChanged(object sender, EventArgs e)
        {
            var producto = DatosSistema.Inventario.FirstOrDefault(x =>
            x.TipoSueter == cmbTallaV.Text &&
            x.Talla == cmbTallaV.Text);

            if (producto != null)
            {
                lblStock.Text = producto.Stock.ToString();
                lblPrecio.Text = producto.PrecioVenta.ToString("C");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var producto = DatosSistema.Inventario.FirstOrDefault(x =>
             x.TipoSueter == cmbTipoV.Text &&
             x.Talla == cmbTallaV.Text);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado");
                return;
            }

            dataGridView1.Rows.Add(
                producto.Codigo,
                producto.TipoSueter,
                producto.Talla,
                npCantidadV.Value,
                producto.PrecioVenta,
                producto.PrecioVenta * npCantidadV.Value
            );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            var producto = DatosSistema.Inventario.FirstOrDefault(x =>
                x.TipoSueter == cmbTipoV.Text &&
                x.Talla == cmbTallaV.Text);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            decimal subtotal =
                producto.PrecioVenta * npCantidadV.Value;

            dataGridView1.Rows[indiceSeleccionado].Cells[0].Value =
                producto.Codigo;

            dataGridView1.Rows[indiceSeleccionado].Cells[1].Value =
                producto.TipoSueter;

            dataGridView1.Rows[indiceSeleccionado].Cells[2].Value =
                producto.Talla;

            dataGridView1.Rows[indiceSeleccionado].Cells[3].Value =
                npCantidadV.Value;

            dataGridView1.Rows[indiceSeleccionado].Cells[4].Value =
                producto.PrecioVenta;

            dataGridView1.Rows[indiceSeleccionado].Cells[5].Value =
                subtotal;

            MessageBox.Show("Producto modificado correctamente.");
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            string recibo = "========== FUN ENGLISH ==========\n";
            recibo += "      RECIBO DE VENTA\n\n";

            recibo += "Encargado: " + txtEncarV.Text + "\n";
            recibo += "Cliente: " + txtNomV.Text + "\n";
            recibo += "Identificación: " + txtIdenV.Text + "\n";
            recibo += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n\n";

            recibo += "PRODUCTOS:\n";
            recibo += "---------------------------------\n";

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;

                recibo +=
                    fila.Cells[1].Value + " | " +
                    fila.Cells[2].Value + " | Cant: " +
                    fila.Cells[3].Value + " | Q" +
                    fila.Cells[5].Value + "\n";

                total += Convert.ToDecimal(fila.Cells[5].Value);
            }

            recibo += "\n---------------------------------\n";
            recibo += "TOTAL A PAGAR: Q" + total.ToString("N2");
            recibo += "\n=================================";

            MessageBox.Show(
                recibo,
                "Recibo de Venta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este producto de la venta?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(indiceSeleccionado);

                indiceSeleccionado = -1;

                MessageBox.Show("Producto eliminado.");
            }
        }
    }
}
