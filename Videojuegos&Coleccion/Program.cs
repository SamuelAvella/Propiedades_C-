using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuegos_Coleccion
{
    public class Videojuego
    {
        public string Nombre { get; set; }
        public string Plataforma { get; set; }
        public bool Jugado { get; set; }

        public Videojuego(string nombre, string plataforma, bool jugado = false)
        {
            Nombre = nombre;
            Plataforma = plataforma;
            Jugado = jugado;
        }
    }

    public class ColeccionVideojuegos
    {
        private List<Videojuego> juegos;

        public ColeccionVideojuegos()
        {
            juegos = new List<Videojuego>();
        }

        public void AgregarJuego(Videojuego juego)
        {
            juegos.Add(juego);
            Console.WriteLine($"El videojuego '{juego.Nombre}' ha sido agregado a la colección.");
        }

        public void EliminarJuego(string nombre)
        {
            Videojuego juegoAEliminar = juegos.Find(juego => juego.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (juegoAEliminar != null)
            {
                juegos.Remove(juegoAEliminar);
                Console.WriteLine($"El videojuego '{nombre}' ha sido eliminado de la colección.");
            }
            else
            {
                Console.WriteLine($"No se encontró un videojuego con el nombre '{nombre}'.");
            }
        }

        public void ListarVideojuegos()
        {
            Console.WriteLine("\nLista de videojuegos en la colección:");
            if (juegos.Count == 0)
            {
                Console.WriteLine("No hay videojuegos en la colección.");
                return;
            }

            foreach (Videojuego juego in juegos)
            {
                Console.WriteLine($"- {juego.Nombre} (Plataforma: {juego.Plataforma}) - Jugado: {(juego.Jugado ? "Sí" : "No")}");
            }
        }

        public void MarcarComoJugado(string nombre)
        {
            Videojuego juegoAMarcar = juegos.Find(juego => juego.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (juegoAMarcar != null)
            {
                juegoAMarcar.Jugado = true;
                Console.WriteLine($"El videojuego '{nombre}' ha sido marcado como jugado.");
            }
            else
            {
                Console.WriteLine($"No se encontró un videojuego con el nombre '{nombre}'.");
            }
        }

        public void ListarVideojuegosJugados()
        {
            Console.WriteLine("\nLista de videojuegos jugados:");
            bool hayJugados = false;

            foreach (Videojuego juego in juegos)
            {
                if (juego.Jugado)
                {
                    Console.WriteLine($"- {juego.Nombre} (Plataforma: {juego.Plataforma})");
                    hayJugados = true;
                }
            }

            if (!hayJugados)
            {
                Console.WriteLine("No hay videojuegos que hayan sido marcados como jugados.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ColeccionVideojuegos coleccion = new ColeccionVideojuegos();

            coleccion.AgregarJuego(new Videojuego("The Legend of Zelda: Breath of the Wild", "Nintendo Switch"));
            coleccion.AgregarJuego(new Videojuego("God of War", "PlayStation 4"));
            coleccion.AgregarJuego(new Videojuego("Minecraft", "PC"));

            coleccion.ListarVideojuegos();

            coleccion.MarcarComoJugado("God of War");
            coleccion.MarcarComoJugado("Minecraft");

            coleccion.ListarVideojuegosJugados();

            coleccion.EliminarJuego("Minecraft");
            coleccion.ListarVideojuegos();
        }
    }
}
