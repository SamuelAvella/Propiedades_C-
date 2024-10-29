using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas
{
    public class Factura
    {
        public int Numero { get; set; }
        public string Concepto { get; set; }
        public double Importe { get; set; }

        public Factura(int numero, string concepto, double importe)
        {
            Numero = numero;
            Concepto = concepto;
            Importe = importe;
        }
    }

    public class GestionFacturas
    {
        private List<Factura> facturas = new List<Factura>();

        public void AgregarFactura(Factura factura)
        {
            facturas.Add(factura);
        }

        public void EliminarFactura(int numero)
        {
            Factura facturaAEliminar = facturas.Find(f => f.Numero == numero);
            facturas.Remove(facturaAEliminar);
        }

        public void ListarFacturas()
        {
            foreach (var factura in facturas)
            {
                Console.WriteLine($"Numero: {factura.Numero}, Concepto: {factura.Concepto}, Importe: {factura.Importe}");
            }
        }

        public double CalcularImporteTotal()
        {
            return facturas.Sum(f => f.Importe);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n== GestionFacturas ==");

            GestionFacturas gestionFacturas = new GestionFacturas();
            gestionFacturas.AgregarFactura(new Factura(1, "Compra de materiales", 250.75));
            gestionFacturas.AgregarFactura(new Factura(2, "Servicio de mantenimiento", 100.50));
            gestionFacturas.AgregarFactura(new Factura(3, "Venta de productos", 300.00));

            Console.WriteLine("Lista de facturas:");
            gestionFacturas.ListarFacturas();

            Console.WriteLine("\nImporte total de todas las facturas:");
            Console.WriteLine(gestionFacturas.CalcularImporteTotal());
        }
    }
}
