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
    public partial class ControlNotas : Form
    {
        public ControlNotas()
        {
            InitializeComponent();
        }

        int fila = -1;        

        private void ControlNotas_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            for (int i = 0; i < ClaseAlumnos.ListaAlumnos.Count; i++)
            {
                var a = ClaseAlumnos.ListaAlumnos[i];
                dataGridView1.Rows.Add(a.Carrera, a.Curso, a.Nombres, a.Apellidos, a.Nota1, a.Nota2, a.Nota3, a.Nota4, a.CalcularPromedio());                
            }            
            txtNota.Enabled = false;
            fila = -1;
        }
  
        private bool Validacion()
        {
            errorProvider1.Clear();
            double val;
            if (!double.TryParse(txtNota.Text, out val))
            {
                errorProvider1.SetError(txtNota, "Ingrese una nota válida");
                return false;
            }
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                fila = dataGridView1.CurrentRow.Index;
                var a = ClaseAlumnos.ListaAlumnos[fila];                
                txtNota.Text = string.Empty;                

                bool todasLlenas = a.Nota1 > 0 && a.Nota2 > 0 && a.Nota3 > 0 && a.Nota4 > 0;
                txtNota.Enabled = !todasLlenas;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validacion()) return;
            if (fila < 0 || fila >= ClaseAlumnos.ListaAlumnos.Count)
            {
                MessageBox.Show("Seleccione un registro en la tabla para asignar la nota.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var existente = ClaseAlumnos.ListaAlumnos[fila];
            double nota = double.Parse(txtNota.Text);

            if (existente.Nota1 == 0) existente.Nota1 = nota;
            else if (existente.Nota2 == 0) existente.Nota2 = nota;
            else if (existente.Nota3 == 0) existente.Nota3 = nota;
            else if (existente.Nota4 == 0) existente.Nota4 = nota;
            else
            {
                MessageBox.Show("Ya se ingresaron 4 notas para este estudiante.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            dataGridView1.Rows[fila].Cells[4].Value = existente.Nota1;
            dataGridView1.Rows[fila].Cells[5].Value = existente.Nota2;
            dataGridView1.Rows[fila].Cells[6].Value = existente.Nota3;
            dataGridView1.Rows[fila].Cells[7].Value = existente.Nota4;
            dataGridView1.Rows[fila].Cells[8].Value = existente.CalcularPromedio();
            
            if (existente.Nota1 > 0 && existente.Nota2 > 0 && existente.Nota3 > 0 && existente.Nota4 > 0)
            {
                MessageBox.Show("Se ingresaron las 4 notas para este estudiante.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNota.Enabled = false;
            }
            else
            {                
                txtNota.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {            
            if (fila < 0 || fila >= ClaseAlumnos.ListaAlumnos.Count) return;
            if (!double.TryParse(txtNota.Text, out double nota)) return;

            var existente = ClaseAlumnos.ListaAlumnos[fila];            
            if (existente.Nota4 != 0) existente.Nota4 = nota;
            else if (existente.Nota3 != 0) existente.Nota3 = nota;
            else if (existente.Nota2 != 0) existente.Nota2 = nota;
            else if (existente.Nota1 != 0) existente.Nota1 = nota;

            dataGridView1.Rows[fila].Cells[4].Value = existente.Nota1;
            dataGridView1.Rows[fila].Cells[5].Value = existente.Nota2;
            dataGridView1.Rows[fila].Cells[6].Value = existente.Nota3;
            dataGridView1.Rows[fila].Cells[7].Value = existente.Nota4;
            dataGridView1.Rows[fila].Cells[8].Value = existente.CalcularPromedio();            
            bool todasLlenasMod = existente.Nota1 > 0 && existente.Nota2 > 0 && existente.Nota3 > 0 && existente.Nota4 > 0;
            txtNota.Enabled = !todasLlenasMod;
        }        

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
