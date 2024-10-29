using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenamientoEnLaNube
{
    public class Archivo
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Tamano { get; set; } 

        public Archivo(string nombre, string tipo, double tamano)
        {
            Nombre = nombre;
            Tipo = tipo;
            Tamano = tamano;
        }
    }

    public class NubeAlmacenamiento
    {
        private List<Archivo> archivos = new List<Archivo>();
        private const double LimiteAlmacenamiento = 500.0;

        public bool SubirArchivo(Archivo archivo)
        {
            double espacioUsado = CalcularEspacioUsado();
            if (espacioUsado + archivo.Tamano <= LimiteAlmacenamiento)
            {
                archivos.Add(archivo);
                Console.WriteLine($"Archivo '{archivo.Nombre}' subido exitosamente.");
                return true;
            }
            else
            {
                Console.WriteLine("No hay suficiente espacio en la nube.");
                return false;
            }
        }

        public bool EliminarArchivo(string nombre)
        {
            Archivo archivo = archivos.Find(a => a.Nombre == nombre);
            if (archivo != null)
            {
                archivos.Remove(archivo);
                Console.WriteLine($"Archivo '{nombre}' eliminado exitosamente.");
                return true;
            }
            else
            {
                Console.WriteLine($"El archivo '{nombre}' no se encontró.");
                return false;
            }
        }

        public void ListarArchivos()
        {
            Console.WriteLine("Archivos en la nube:");
            foreach (var archivo in archivos)
            {
                Console.WriteLine($"- {archivo.Nombre} ({archivo.Tipo}, {archivo.Tamano} MB)");
            }
        }

        public void BuscarArchivo(string nombre)
        {
            Archivo archivo = archivos.Find(a => a.Nombre == nombre);
            if (archivo != null)
            {
                Console.WriteLine($"Archivo encontrado: {archivo.Nombre} ({archivo.Tipo}, {archivo.Tamano} MB)");
            }
            else
            {
                Console.WriteLine($"El archivo '{nombre}' no se encontró.");
            }
        }

        public double CalcularEspacioDisponible()
        {
            return LimiteAlmacenamiento - CalcularEspacioUsado();
        }

        private double CalcularEspacioUsado()
        {
            return archivos.Sum(a => a.Tamano);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            NubeAlmacenamiento nube = new NubeAlmacenamiento();
            nube.SubirArchivo(new Archivo("documento1.txt", "documento", 20));
            nube.SubirArchivo(new Archivo("imagen1.jpg", "imagen", 50));
            nube.ListarArchivos();
            nube.BuscarArchivo("documento1.txt");
            Console.WriteLine($"Espacio disponible: {nube.CalcularEspacioDisponible()} MB");
            nube.EliminarArchivo("documento1.txt");
            nube.ListarArchivos();
        }
    }
}
