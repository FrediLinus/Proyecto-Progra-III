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
    public partial class Asitencia : Form
    {
        public Asitencia()
        {
            InitializeComponent();
            rbSi.Checked = true;
        }
        char ok = 'f'; int fila;
        string asistencia;
        
        private class StudentItem
        {
            public int Index { get; set; }
            public string Nombre { get; set; }
            public override string ToString() => Nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rbSi.Checked == true)
            {
                asistencia = "Si";
            }
            else if (rbNo.Checked == true)
            {
                asistencia = "No";
            }
            else if (rbPermiso.Checked == true)
            {
                asistencia = "Permiso";
            }            
            if (fila < 0 || fila >= ClaseAlumnos.ListaAlumnos.Count)
            {
                MessageBox.Show("Seleccione un registro en la tabla para actualizar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var existente = ClaseAlumnos.ListaAlumnos[fila];
            
            if (cmbEstudiante.SelectedItem is StudentItem si)
            {
                var seleccionado = ClaseAlumnos.ListaAlumnos[si.Index];
                if (string.IsNullOrEmpty(existente.Nombres)) existente.Nombres = seleccionado.Nombres;
                if (string.IsNullOrEmpty(existente.Apellidos)) existente.Apellidos = seleccionado.Apellidos;
            }

            if (string.IsNullOrEmpty(existente.Fecha))
                existente.Fecha = date.Value.ToShortDateString();
            
            if (string.IsNullOrEmpty(existente.Asistencia))
                existente.Asistencia = asistencia;
            
            dataGridView1.Rows[fila].Cells[0].Value = existente.Carrera;
            dataGridView1.Rows[fila].Cells[1].Value = existente.Curso;
            dataGridView1.Rows[fila].Cells[2].Value = existente.Nombres;
            dataGridView1.Rows[fila].Cells[3].Value = existente.Apellidos;
            dataGridView1.Rows[fila].Cells[4].Value = existente.Fecha;
            dataGridView1.Rows[fila].Cells[5].Value = existente.Asistencia;
            ok = 'v';
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            if (!Validacion()) return;

            if (fila >= 0 && fila < ClaseAlumnos.ListaAlumnos.Count)
            {
                var existente = ClaseAlumnos.ListaAlumnos[fila];
                existente.Carrera = cmbCarrera.Text;
                existente.Curso = cmbCurso.Text;
                
                if (cmbEstudiante.SelectedItem is StudentItem si)
                {
                    var seleccion = ClaseAlumnos.ListaAlumnos[si.Index];
                    existente.Nombres = seleccion.Nombres;
                    existente.Apellidos = seleccion.Apellidos;
                }
                
                existente.Fecha = date.Value.ToShortDateString();
                if (rbSi.Checked) existente.Asistencia = "Si";
                else if (rbNo.Checked) existente.Asistencia = "No";
                else if (rbPermiso.Checked) existente.Asistencia = "Permiso";
                
                dataGridView1.Rows[fila].Cells[0].Value = existente.Carrera;
                dataGridView1.Rows[fila].Cells[1].Value = existente.Curso;
                dataGridView1.Rows[fila].Cells[2].Value = existente.Nombres;
                dataGridView1.Rows[fila].Cells[3].Value = existente.Apellidos;
                dataGridView1.Rows[fila].Cells[4].Value = existente.Fecha;
                dataGridView1.Rows[fila].Cells[5].Value = existente.Asistencia;
                MessageBox.Show("Registro modificado", "Modificaion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void Asitencia_Load(object sender, EventArgs e)
        {            
            UpdateCursosForCarrera();            
            for (int i = 0; i < ClaseAlumnos.ListaAlumnos.Count; i++)
            {
                var a = ClaseAlumnos.ListaAlumnos[i];
                dataGridView1.Rows.Add(a.Carrera, a.Curso, a.Nombres, a.Apellidos, a.Fecha, a.Asistencia);
                ok = 'v';
            }
        }

        private void UpdateCursosForCarrera()
        {
            cmbCurso.Items.Clear();
            cmbEstudiante.Items.Clear();

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
            var estudiantes = ClaseAlumnos.ListaAlumnos
                .Select((a, idx) => new { a, idx })
                .Where(x => x.a.Carrera == cmbCarrera.Text)
                .ToList();

            foreach (var entry in estudiantes)
            {                
                cmbEstudiante.Items.Add(new StudentItem { Index = entry.idx, Nombre = entry.a.Nombres });
            }

            if (cmbCurso.Items.Count > 0)
                cmbCurso.SelectedIndex = 0;
            if (cmbEstudiante.Items.Count > 0)
                cmbEstudiante.SelectedIndex = 0;
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCursosForCarrera();
        }

        private bool Validacion()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(cmbEstudiante.Text))
            {
                errorProvider1.SetError(cmbEstudiante, "Seleccione un estudiante");
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
                cmbEstudiante.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                var asistenciaVal = dataGridView1.Rows[fila].Cells[3].Value.ToString();
                rbSi.Checked = asistenciaVal == "Si";
                rbNo.Checked = asistenciaVal == "No";
                rbPermiso.Checked = asistenciaVal == "Permiso";
            }
        }
    }
}
