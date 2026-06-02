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

            if (string.IsNullOrEmpty(existente.Fecha))
                existente.Fecha = date.Value.ToShortDateString();

            if (string.IsNullOrEmpty(existente.Asistencia))
                existente.Asistencia = asistencia;
            
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

                existente.Fecha = date.Value.ToShortDateString();
                if (rbSi.Checked) existente.Asistencia = "Si";
                else if (rbNo.Checked) existente.Asistencia = "No";
                else if (rbPermiso.Checked) existente.Asistencia = "Permiso";

                dataGridView1.Rows[fila].Cells[4].Value = existente.Fecha;
                dataGridView1.Rows[fila].Cells[5].Value = existente.Asistencia;
                MessageBox.Show("Registro modificado", "Modificaion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }        

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void Asitencia_Load(object sender, EventArgs e)
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
                dataGridView1.Rows.Add(a.Carrera, a.Curso, a.Nombres, a.Apellidos, a.Fecha, a.Asistencia);
                ok = 'v';
            }
        }

        private bool Validacion()
        {
            errorProvider1.Clear();            
            if (fila < 0 || fila >= ClaseAlumnos.ListaAlumnos.Count)
            {
                errorProvider1.SetError(dataGridView1, "Seleccione un registro de la tabla");
                return false;
            }
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                fila = dataGridView1.CurrentRow.Index;                
                var fechaVal = dataGridView1.Rows[fila].Cells[4].Value?.ToString();
                if (DateTime.TryParse(fechaVal, out DateTime dt))
                    date.Value = dt;                

                var asistenciaVal = dataGridView1.Rows[fila].Cells[5].Value?.ToString() ?? string.Empty;
                if (string.IsNullOrEmpty(asistenciaVal))
                {                    
                    rbSi.Checked = true;
                    rbNo.Checked = false;
                    rbPermiso.Checked = false;
                }
                else
                {
                    rbSi.Checked = asistenciaVal == "Si";
                    rbNo.Checked = asistenciaVal == "No";
                    rbPermiso.Checked = asistenciaVal == "Permiso";
                }
            }
        }
    }
}
