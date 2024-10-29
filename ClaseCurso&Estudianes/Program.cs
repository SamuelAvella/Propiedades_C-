using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseCurso_Estudianes
{
    public class Estudiante
    {
        public String Nombre { get; set; }
        public Double Calificacion { get; set; }

        public Estudiante(string nombre, double calificacion)
        {
            Nombre = nombre;
            Calificacion = calificacion;
        }
    }

    public class Curso
    {
        public string Nombre { get; set; }
        private List<Estudiante> estudiantes = new List<Estudiante>();

        public void AgregarEstudiante(Estudiante estudiante)
        {
            estudiantes.Add(estudiante);
        }

        public void EliminarEstudiante(string nombre)
        {
            Estudiante estudianteAEliminar = estudiantes.Find(f => f.Nombre == nombre);
            estudiantes.Remove(estudianteAEliminar);
        }

        public double CalcularCalificacionMedia()
        {
            if (estudiantes.Count == 0) return 0;
            return estudiantes.Average(e => e.Calificacion);
        }

        public void ListarEstudiantes()
        {
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"Nombre: {estudiante.Nombre}, Calificación: {estudiante.Calificacion}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n== Curso ==");

            Curso curso = new Curso { Nombre = "Programación" };
            curso.AgregarEstudiante(new Estudiante("Lucía", 8.9));
            curso.AgregarEstudiante(new Estudiante("Pedro", 7.5));
            curso.AgregarEstudiante(new Estudiante("Marta", 9.3));

            Console.WriteLine("Lista de estudiantes en el curso:");
            curso.ListarEstudiantes();

            Console.WriteLine("\nCalificación media del curso:");
            Console.WriteLine(curso.CalcularCalificacionMedia());
        }
    }
}
