using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Producto
{
    internal class Producto
    {
        private String nombre;
        private Double precio;
        private int cantidad;

        public Producto(string nombre, double precio, int cantidad)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;

        }

        public string Nombre
        {
            get { return nombre; }
            set {  nombre = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set {  cantidad = value; }
        }

        public override String ToString()
        {
            return $"Producto: {nombre}, Precio: {precio}, Cantidad: {cantidad}";
        }

        public void AumentarCantidad(int cantidad)
        {
            this.cantidad = this.cantidad + cantidad;
        }

        public void ReducirCantidad(int cantidad)
        {
            this.cantidad = this.cantidad - cantidad;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca los siguientes datos para crear su producto");

            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto (opcional, deje en blanco para 0): ");
            string precioInput = Console.ReadLine();
            double precio = 0;
            if (!string.IsNullOrEmpty(precioInput))
            {
                precio = Convert.ToDouble(precioInput);
            }

            Console.Write("Ingrese la cantidad del producto (opcional, deje en blanco para 0): ");
            string cantidadInput = Console.ReadLine();
            int cantidad = 0;
            if (!string.IsNullOrEmpty(cantidadInput))
            {
                cantidad = Convert.ToInt32(cantidadInput);
            }

            Producto producto = new Producto(nombre, precio, cantidad);
            Console.WriteLine("Producto creado: " + producto.ToString());

            Console.Write("¿Desea aumentar la cantidad? Ingrese la cantidad a aumentar o deje en blanco para omitir: ");
            string aumentarInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(aumentarInput))
            {
                int cantidadAumentar = Convert.ToInt32(aumentarInput);
                producto.AumentarCantidad(cantidadAumentar);
                Console.WriteLine($"Cantidad actualizada: {producto.Cantidad}");
            }

            Console.Write("¿Desea reducir la cantidad? Ingrese la cantidad a reducir o deje en blanco para omitir: ");
            string reducirInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(reducirInput))
            {
                int cantidadReducir = Convert.ToInt32(reducirInput);
                producto.ReducirCantidad(cantidadReducir);
                Console.WriteLine($"Cantidad actualizada: {producto.Cantidad}");
            }

            Console.WriteLine("Su producto final: " + producto.ToString());


        }
    }
}
