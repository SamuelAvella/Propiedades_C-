using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Alumno
    {
        public String Nombre { get; set; }

        public int Edad { get; set; }

        public Double NotaMedia { get; set; }

        public Alumno(string nombre, int edad, double notaMedia)
        {
            Nombre = nombre;
            Edad = edad;
            NotaMedia = notaMedia;
        }
    }

    public class ClaseAlumnos
    {
        private List<Alumno> alumnos = new List<Alumno>();

        public void AgregarAlumno(Alumno alumno)
        {
            alumnos.Add(alumno);
        }

        public void EliminarAlumno(string nombre)
        {
            alumnos.RemoveAll(a => a.Nombre == nombre);
        }

        public void ListarAlumnos()
        {
            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"Nombre: {alumno.Nombre}, Edad: {alumno.Edad}, Nota Media: {alumno.NotaMedia}");
            }
        }

        public Alumno BuscarAlumno(string nombre)
        {
            return alumnos.Find(a => a.Nombre == nombre);
        }

        public double CalcularNotaMedia()
        {
            if (alumnos.Count == 0) return 0;
            return alumnos.Average(a => a.NotaMedia);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== ClaseAlumnos ==");

            ClaseAlumnos claseAlumnos = new ClaseAlumnos();
            claseAlumnos.AgregarAlumno(new Alumno("Juan", 20, 8.5));
            claseAlumnos.AgregarAlumno(new Alumno("Ana", 22, 9.1));
            claseAlumnos.AgregarAlumno(new Alumno("Luis", 21, 7.3));

            Console.WriteLine("Lista de alumnos:");
            claseAlumnos.ListarAlumnos();

            Console.WriteLine("\nBuscar alumno 'Ana':");
            Alumno alumno = claseAlumnos.BuscarAlumno("Ana");
            if (alumno != null)
                Console.WriteLine($"Nombre: {alumno.Nombre}, Edad: {alumno.Edad}, Nota Media: {alumno.NotaMedia}");

            Console.WriteLine("\nNota media de la clase:");
            Console.WriteLine(claseAlumnos.CalcularNotaMedia());
        }
    }
}
