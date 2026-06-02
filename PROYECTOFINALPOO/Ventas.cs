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

        // Validacion: solo numeros en identificacion
        private void txtIdenV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCamposVenta()
        {
            if (string.IsNullOrWhiteSpace(cmbTipoV.Text) ||
                string.IsNullOrWhiteSpace(cmbTallaV.Text) )
            {
                MessageBox.Show("Por favor seleccione tipo y talla.");
                return false;
            }

            return true;
        }

        private bool ValidarCamposVentaCliente()
        {
            if (string.IsNullOrWhiteSpace(txtEncarV.Text) ||
                string.IsNullOrWhiteSpace(txtNomV.Text) ||
                string.IsNullOrWhiteSpace(txtIdenV.Text))
            {
                MessageBox.Show("Por favor complete los datos del cliente.");
                return false;
            }

            return true;
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
            if (!ValidarCamposVenta()) return;

            var producto = DatosSistema.Inventario.FirstOrDefault(x =>
             x.TipoSueter == cmbTipoV.Text &&
             x.Talla == cmbTallaV.Text);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado");
                return;
            }

            int requested = Convert.ToInt32(npCantidadV.Value);

            // calcular cantidad ya agregada en la grilla para este producto
            int alreadyAdded = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && r.Cells[0].Value != null && r.Cells[0].Value.ToString() == producto.Codigo)
                .Sum(r => Convert.ToInt32(r.Cells[3].Value));

            if (alreadyAdded + requested > producto.Stock)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {producto.Stock - alreadyAdded}");
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

            int requested = Convert.ToInt32(npCantidadV.Value);

            // calcular cantidad ya agregada en la grilla para este producto excluyendo la fila que se modifica
            int alreadyAdded = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where((r, i) => !r.IsNewRow && r.Cells[0].Value != null && r.Cells[0].Value.ToString() == producto.Codigo && dataGridView1.Rows.IndexOf(r) != indiceSeleccionado)
                .Sum(r => Convert.ToInt32(r.Cells[3].Value));

            if (alreadyAdded + requested > producto.Stock)
            {
                MessageBox.Show($"Stock insuficiente para la modificación. Disponible: {producto.Stock - alreadyAdded}");
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
            if (!ValidarCamposVentaCliente()) return;
            // No permitir generar venta si no hay productos agregados
            if (!dataGridView1.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow))
            {
                MessageBox.Show("No hay productos agregados a la venta.");
                return;
            }

            // Validar que las cantidades solicitadas no excedan el stock actual
            var grupos = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && r.Cells[0].Value != null)
                .GroupBy(r => r.Cells[0].Value.ToString())
                .Select(g => new { Codigo = g.Key, Cantidad = g.Sum(r => Convert.ToInt32(r.Cells[3].Value)) });

            foreach (var g in grupos)
            {
                var prod = DatosSistema.Inventario.FirstOrDefault(x => x.Codigo == g.Codigo);
                if (prod == null)
                {
                    MessageBox.Show($"Producto con código {g.Codigo} no se encontró en inventario.");
                    return;
                }

                if (g.Cantidad > prod.Stock)
                {
                    MessageBox.Show($"Stock insuficiente para el producto {prod.TipoSueter} talla {prod.Talla}. Disponible: {prod.Stock}, solicitado: {g.Cantidad}.");
                    return;
                }
            }
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

            // Descontar del inventario las cantidades vendidas
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;

                var codigo = fila.Cells[0].Value?.ToString();
                if (string.IsNullOrWhiteSpace(codigo)) continue;

                int qty = Convert.ToInt32(fila.Cells[3].Value);

                var prod = DatosSistema.Inventario.FirstOrDefault(x => x.Codigo == codigo);
                if (prod != null)
                {
                    prod.Stock -= qty;
                    if (prod.Stock < 0) prod.Stock = 0;
                }
            }

            // Limpiar la lista de venta
            dataGridView1.Rows.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Menu_Admin menu = new Menu_Admin();
            menu.Show();
            this.Hide();

        }
    }
}
