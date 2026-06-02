using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOFINALPOO
{
    internal class ClaseAlumnos
    {
        public string Carrera { get; set; }

        public string Curso { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Asistencia { get; set; }

        public double Nota { get; set; }
        
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }

        public string Fecha { get; set; }
        
        public static List<ClaseAlumnos> ListaAlumnos { get; } = new List<ClaseAlumnos>();

        public ClaseAlumnos(string carrera, string curso, string nombres, string apellidos, string asistencia, double nota, string fecha = "")
        {
            Carrera = carrera;
            Curso = curso;
            Nombres = nombres;
            Apellidos = apellidos;
            Asistencia = asistencia;
            Nota = nota;
            Fecha = fecha;
        }
        
        public static void Agregar(string carrera, string curso, string nombres, string apellidos, string asistencia, double nota, string fecha = "")
        {
            ListaAlumnos.Add(new ClaseAlumnos(carrera, curso, nombres, apellidos, asistencia, nota, fecha));
        }

        public void RecibirDatos(string carrera, string curso, string nombres, string apellidos, string asistencia, double nota)
        {
            Carrera = carrera;
            Curso = curso;
            Nombres = nombres;
            Apellidos = apellidos;
            Asistencia = asistencia;
            Nota = nota;

            if (!ListaAlumnos.Contains(this))
                ListaAlumnos.Add(this);
        }
        
        public void RecibirDatos(string carrera, string curso, string nombres, string apellidos, string asistencia, double nota, string fecha)
        {
            Carrera = carrera;
            Curso = curso;
            Nombres = nombres;
            Apellidos = apellidos;
            Asistencia = asistencia;
            Nota = nota;
            Fecha = fecha;

            if (!ListaAlumnos.Contains(this))
                ListaAlumnos.Add(this);
        }
        
        public double CalcularPromedio()
        {
            var notas = new List<double>();
            if (Nota1 > 0) notas.Add(Nota1);
            if (Nota2 > 0) notas.Add(Nota2);
            if (Nota3 > 0) notas.Add(Nota3);
            if (Nota4 > 0) notas.Add(Nota4);
            if (notas.Count == 0) return 0;
            return Math.Round(notas.Average(), 2);
        }
    }
}
