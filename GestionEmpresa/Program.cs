using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresa
{
    public class Empleado
    {
        public String Nombre { get; set; }
        public String Puesto { get; set; }
        public int Salario { get; set; }

        public Empleado(String nombre, String puesto, int salario)
        {

            this.Nombre = nombre;
            this.Puesto = puesto;
            this.Salario = salario;
        }
    }

    public class Empresa
    {
        public List<Empleado> empresa = new List<Empleado>();

        public void AgregarEmpleado(Empleado empleado)
        {
            empresa.Add(empleado);
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            empresa.Remove(empleado);
        }

        public void ListarEmpleados()
        {
            foreach (var empleado in empresa)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Puesto: {empleado.Puesto}, Salario: {empleado.Salario}");
            }
        }

        public double CalcularSalarioPromedio()
        {
            if (empresa.Count == 0) { return 0; }
            return empresa.Average(e => e.Salario);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n== Empresa ==");

            Empresa empresa = new Empresa();
            empresa.AgregarEmpleado(new Empleado("Carlos", "Gerente", 5000));
            empresa.AgregarEmpleado(new Empleado("Maria", "Desarrolladora", 3500));
            empresa.AgregarEmpleado(new Empleado("Jorge", "Diseñador", 3000));

            Console.WriteLine("Lista de empleados:");
            empresa.ListarEmpleados();

            Console.WriteLine("\nSalario promedio de la empresa:");
            Console.WriteLine(empresa.CalcularSalarioPromedio());
        }
    }
}
