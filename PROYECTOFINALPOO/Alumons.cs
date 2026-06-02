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
    public partial class Alumons : Form
    {
        public Alumons()
        {
            InitializeComponent();            
        }        
        char ok = 'f'; int fila;
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Validacion() == true)
            {                
                ClaseAlumnos.Agregar(cmbCarrera.Text, cmbCurso.Text, txtNombres.Text, txtApellidos.Text, "", 0);
                var nuevo = ClaseAlumnos.ListaAlumnos.Last();
                dataGridView1.Rows.Add(nuevo.Carrera, nuevo.Curso, nuevo.Nombres, nuevo.Apellidos);
                ok = 'v';
                txtApellidos.Clear();
                txtNombres.Clear();
            }
            
        }

        private void Alumons_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            
            foreach (var a in ClaseAlumnos.ListaAlumnos)
            {
                dataGridView1.Rows.Add(a.Carrera, a.Curso, a.Nombres, a.Apellidos);
                ok = 'v';
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Validacion() == true)
            {                
                if (fila >= 0 && fila < ClaseAlumnos.ListaAlumnos.Count)
                {
                    var existente = ClaseAlumnos.ListaAlumnos[fila];
                    existente.Carrera = cmbCarrera.Text;
                    existente.Curso = cmbCurso.Text;
                    existente.Nombres = txtNombres.Text;
                    existente.Apellidos = txtApellidos.Text;

                    dataGridView1.Rows[fila].Cells[0].Value = existente.Carrera;
                    dataGridView1.Rows[fila].Cells[1].Value = existente.Curso;
                    dataGridView1.Rows[fila].Cells[2].Value = existente.Nombres;
                    dataGridView1.Rows[fila].Cells[3].Value = existente.Apellidos;
                }
                MessageBox.Show("Registro modificado", "Modificaion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellidos.Clear();
                txtNombres.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ok == 'f')
            {
                MessageBox.Show("No hay registros");
            }
            else
            {                
                if (fila >= 0 && fila < ClaseAlumnos.ListaAlumnos.Count)
                {
                    ClaseAlumnos.ListaAlumnos.RemoveAt(fila);
                    dataGridView1.Rows.RemoveAt(fila);
                }
                MessageBox.Show("Registro eliminado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApellidos.Clear();
                txtNombres.Clear();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCursosForCarrera();            
            if (cmbCurso.Items.Count > 0)
                cmbCurso.SelectedIndex = 0;
        }

        private Boolean Validacion()
        {
            Boolean validar = false;
            errorProvider1.Clear();
            if (txtNombres.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombres, "Campo Obligatorio");
            }
            else if (txtApellidos.Text == string.Empty)
            {
                errorProvider1.SetError(txtApellidos, "Campo Obligatorio");
            }            
            else
            {
                validar = true;
            }
            return validar;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                fila = dataGridView1.CurrentRow.Index;
                cmbCarrera.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                cmbCurso.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                txtNombres.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                txtApellidos.Text = dataGridView1.Rows[fila].Cells[3].Value.ToString();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
