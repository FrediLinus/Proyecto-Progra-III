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

        char ok = 'f'; int fila = -1;        

        private void ControlNotas_Load(object sender, EventArgs e)
        {            
            for (int i = 0; i < ClaseAlumnos.ListaAlumnos.Count; i++)
            {
                var a = ClaseAlumnos.ListaAlumnos[i];
                dataGridView1.Rows.Add(a.Carrera, a.Curso, a.Nombres, a.Apellidos, a.Nota1, a.Nota2, a.Nota3, a.Nota4, a.CalcularPromedio());
                ok = 'v';
            }
        }

        private void UpdateCursosForCarrera()
        {
            cmbCurso.Items.Clear();

            if (cmbCarrera.Text == "4to Computacion" || cmbCarrera.Text == "5to Computacion")
            {
                cmbCurso.Items.Add("Programacion");
                cmbCurso.Items.Add("Redes");
                cmbCurso.Items.Add("Base de Datos");
            }
            else if (cmbCarrera.Text == "4to Dibujo" || cmbCarrera.Text == "5to Dibujo")
            {
                cmbCurso.Items.Add("Dibujo Tecnico");
                cmbCurso.Items.Add("Maquetado");
                cmbCurso.Items.Add("Matematica");
            }
            else if (cmbCarrera.Text == "4to Biologicas" || cmbCarrera.Text == "5to Biologicas")
            {
                cmbCurso.Items.Add("Biologia");
                cmbCurso.Items.Add("Quimica");
                cmbCurso.Items.Add("Fisica");
            }

            if (cmbCurso.Items.Count > 0) cmbCurso.SelectedIndex = 0;
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCursosForCarrera();
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
                cmbCarrera.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                UpdateCursosForCarrera();
                cmbCurso.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();                
                var a = ClaseAlumnos.ListaAlumnos[fila];
                if (a.Nota1 == 0) txtNota.Text = "";
                else if (a.Nota2 == 0) txtNota.Text = "";
                else if (a.Nota3 == 0) txtNota.Text = "";
                else txtNota.Text = "";
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (fila >= 0 && fila < ClaseAlumnos.ListaAlumnos.Count)
            {
                ClaseAlumnos.ListaAlumnos.RemoveAt(fila);
                dataGridView1.Rows.RemoveAt(fila);
                fila = -1;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
