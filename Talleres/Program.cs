using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres
{
    public class Coche
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public bool Estado { get; set; }

        public Coche(string matricula, string marca)
        {
            Matricula = matricula;
            Marca = marca;
            Estado = false;
        }
    }

    public class Taller
    {
        private List<Coche> coches = new List<Coche>();

        public void AgregarCoche(Coche coche)
        {
            coches.Add(coche);
        }

        public void EliminarCoche(string matricula)
        {
            Coche cocheAEliminar = coches.Find(c => c.Matricula == matricula);
            coches.Remove(cocheAEliminar);
        }

        public void RepararCoche(string matricula)
        {
            Coche coche = coches.Find(c => c.Matricula == matricula);
            if (coche != null) coche.Estado = true;
        }

        public void ListarCoches()
        {
            foreach (var coche in coches)
            {
                Console.WriteLine($"Matricula: {coche.Matricula}, Marca: {coche.Marca}, Estado: {(coche.Estado ? "Reparado" : "No Reparado")}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n== Taller ==");

            Taller taller = new Taller();
            taller.AgregarCoche(new Coche("ABC123", "Toyota"));
            taller.AgregarCoche(new Coche("XYZ789", "Honda"));
            taller.AgregarCoche(new Coche("LMN456", "Ford"));

            Console.WriteLine("Lista de coches en el taller:");
            taller.ListarCoches();

            Console.WriteLine("\nReparar coche con matrícula 'XYZ789':");
            taller.RepararCoche("XYZ789");

            Console.WriteLine("\nLista de coches después de reparación:");
            taller.ListarCoches();
        }
    }
}
