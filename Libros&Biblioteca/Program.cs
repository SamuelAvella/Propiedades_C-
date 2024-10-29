using System;
using System.Collections.Generic;

namespace Libros_Biblioteca
{
    namespace BibliotecaApp
    {
        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public bool Disponible { get; set; }

            public Libro(string titulo, string autor, bool disponible = true)
            {
                Titulo = titulo;
                Autor = autor;
                Disponible = disponible;
            }
        }

        public class Biblioteca
        {
            private List<Libro> libros;

            public Biblioteca()
            {
                libros = new List<Libro>();
            }

            public void AgregarLibro(Libro libro)
            {
                libros.Add(libro);
                Console.WriteLine($"El libro '{libro.Titulo}' de {libro.Autor} ha sido agregado a la biblioteca.");
            }

            public void EliminarLibro(string titulo)
            {
                Libro libroAEliminar = libros.Find(libro => libro.Titulo == titulo);
                if (libroAEliminar != null)
                {
                    libros.Remove(libroAEliminar);
                    Console.WriteLine($"El libro '{titulo}' ha sido eliminado de la biblioteca.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un libro con el título '{titulo}'.");
                }
            }

            public void ListarLibrosDisponibles()
            {
                Console.WriteLine("\nLibros disponibles en la biblioteca:");
                bool hayDisponibles = false;

                foreach (Libro libro in libros)
                {
                    if (libro.Disponible)
                    {
                        Console.WriteLine($"- {libro.Titulo} de {libro.Autor}");
                        hayDisponibles = true;
                    }
                }

                if (!hayDisponibles)
                {
                    Console.WriteLine("No hay libros disponibles.");
                }
            }

            public void PrestarLibro(string titulo)
            {
                Libro libroAPrestar = libros.Find(libro => libro.Titulo == titulo);
                if (libroAPrestar != null)
                {
                    if (libroAPrestar.Disponible)
                    {
                        libroAPrestar.Disponible = false;
                        Console.WriteLine($"El libro '{titulo}' ha sido prestado.");
                    }
                    else
                    {
                        Console.WriteLine($"El libro '{titulo}' ya está prestado.");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontró un libro con el título '{titulo}'.");
                }
            }

            public void DevolverLibro(string titulo)
            {
                Libro libroADevolver = libros.Find(libro => libro.Titulo == titulo);
                if (libroADevolver != null)
                {
                    if (!libroADevolver.Disponible)
                    {
                        libroADevolver.Disponible = true;
                        Console.WriteLine($"El libro '{titulo}' ha sido devuelto a la biblioteca.");
                    }
                    else
                    {
                        Console.WriteLine($"El libro '{titulo}' ya estaba disponible en la biblioteca.");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontró un libro con el título '{titulo}'.");
                }
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Biblioteca biblioteca = new Biblioteca();

                biblioteca.AgregarLibro(new Libro("Cien Años de Soledad", "Gabriel García Márquez"));
                biblioteca.AgregarLibro(new Libro("Don Quijote de la Mancha", "Miguel de Cervantes"));
                biblioteca.AgregarLibro(new Libro("La Odisea", "Homero"));

                biblioteca.ListarLibrosDisponibles();

                biblioteca.PrestarLibro("Cien Años de Soledad");

                biblioteca.PrestarLibro("Cien Años de Soledad");

                biblioteca.ListarLibrosDisponibles();

                biblioteca.DevolverLibro("Cien Años de Soledad");

                biblioteca.EliminarLibro("La Odisea");

                biblioteca.ListarLibrosDisponibles();
            }
        }
    }
}
