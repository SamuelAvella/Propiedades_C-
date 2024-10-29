using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecomendacionDeLibros
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public double Valoracion { get; set; }

        public Libro(string titulo, string autor, string genero, double valoracion)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Valoracion = valoracion;
        }
    }

    public class SistemaRecomendacionLibros
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Console.WriteLine($"Libro '{libro.Titulo}' agregado al sistema.");
        }

        public void ListarLibrosPorGenero(string genero)
        {
            var librosPorGenero = libros.Where(l => l.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosPorGenero.Any())
            {
                Console.WriteLine($"Libros del género '{genero}':");
                foreach (var libro in librosPorGenero)
                {
                    Console.WriteLine($"- {libro.Titulo} por {libro.Autor} (Valoración: {libro.Valoracion} estrellas)");
                }
            }
            else
            {
                Console.WriteLine($"No hay libros en el género '{genero}'.");
            }
        }

        public void ListarMejoresLibros(int cantidad)
        {
            var mejoresLibros = libros.OrderByDescending(l => l.Valoracion).Take(cantidad).ToList();
            Console.WriteLine("Mejores libros:");
            foreach (var libro in mejoresLibros)
            {
                Console.WriteLine($"- {libro.Titulo} por {libro.Autor} (Valoración: {libro.Valoracion} estrellas)");
            }
        }

        public void RecomendarLibro(string genero)
        {
            var librosPorGenero = libros.Where(l => l.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosPorGenero.Any())
            {
                Random random = new Random();
                var libroRecomendado = librosPorGenero[random.Next(librosPorGenero.Count)];
                Console.WriteLine($"Recomendación: {libroRecomendado.Titulo} por {libroRecomendado.Autor} (Valoración: {libroRecomendado.Valoracion} estrellas)");
            }
            else
            {
                Console.WriteLine($"No hay libros en el género '{genero}' para recomendar.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SistemaRecomendacionLibros sistema = new SistemaRecomendacionLibros();
            sistema.AgregarLibro(new Libro("Cien años de soledad", "Gabriel García Márquez", "Ficción", 5));
            sistema.AgregarLibro(new Libro("El túnel", "Ernesto Sabato", "Ficción", 4.5));
            sistema.AgregarLibro(new Libro("El arte de la guerra", "Sun Tzu", "No ficción", 4));
            sistema.ListarLibrosPorGenero("Ficción");
            sistema.ListarMejoresLibros(2);
            sistema.RecomendarLibro("Ficción");
        }
    }
}
