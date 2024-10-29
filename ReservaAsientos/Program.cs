using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaAsientos
{
    using System;

    class Asiento
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public bool Reservado { get; set; }

        public Asiento(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
            Reservado = false;
        }

        public override string ToString()
        {
            return Reservado ? "R" : "D";  // R = Reservado, D = Disponible
        }
    }

    class SalaCine
    {
        private Asiento[,] asientos;
        private int filas;
        private int columnas;

        public SalaCine(int filas = 5, int columnas = 8)
        {
            this.filas = filas;
            this.columnas = columnas;
            asientos = new Asiento[filas, columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    asientos[i, j] = new Asiento(i, j);
                }
            }
        }

        public void ReservarAsiento(int fila, int columna)
        {
            if (asientos[fila, columna].Reservado)
            {
                Console.WriteLine($"Error: el asiento ({fila + 1}, {columna + 1}) ya está reservado.");
            }
            else
            {
                asientos[fila, columna].Reservado = true;
                Console.WriteLine($"Asiento ({fila + 1}, {columna + 1}) reservado con éxito.");
            }
        }

        public void CancelarReserva(int fila, int columna)
        {
            if (!asientos[fila, columna].Reservado)
            {
                Console.WriteLine($"Error: el asiento ({fila + 1}, {columna + 1}) no está reservado.");
            }
            else
            {
                asientos[fila, columna].Reservado = false;
                Console.WriteLine($"Reserva del asiento ({fila + 1}, {columna + 1}) cancelada con éxito.");
            }
        }

        public void MostrarAsientos()
        {
            Console.WriteLine("\nEstado actual de los asientos:");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(asientos[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void ReservarAsientosGrupo(int numAsientos)
        {
            for (int i = 0; i < filas; i++)
            {
                int consecutivos = 0;
                int inicioBloque = -1;

                for (int j = 0; j < columnas; j++)
                {
                    if (!asientos[i, j].Reservado)
                    {
                        consecutivos++;
                        if (consecutivos == 1)
                            inicioBloque = j;

                        if (consecutivos == numAsientos)
                        {
                            for (int k = inicioBloque; k < inicioBloque + numAsientos; k++)
                            {
                                asientos[i, k].Reservado = true;
                            }
                            Console.WriteLine($"{numAsientos} asientos consecutivos reservados en la fila {i + 1}.");
                            return;
                        }
                    }
                    else
                    {
                        consecutivos = 0;
                    }
                }
            }
            Console.WriteLine($"No se encontraron {numAsientos} asientos consecutivos disponibles en una misma fila.");
        }
    }

    internal class Program
    {
        static void Main()
        {
            // Crear una sala de cine de 5 filas x 8 columnas
            SalaCine sala = new SalaCine();

            // Mostrar asientos iniciales
            sala.MostrarAsientos();

            // Reservar algunos asientos
            sala.ReservarAsiento(1, 2);
            sala.ReservarAsiento(1, 3);
            sala.ReservarAsiento(1, 4);

            // Mostrar asientos después de reservar algunos
            sala.MostrarAsientos();

            // Cancelar la reserva de un asiento
            sala.CancelarReserva(1, 3);

            // Mostrar asientos después de cancelar la reserva de un asiento
            sala.MostrarAsientos();

            // Intentar reservar un grupo de 3 asientos consecutivos
            sala.ReservarAsientosGrupo(3);

            // Mostrar asientos después de intentar reservar un grupo
            sala.MostrarAsientos();

            // Intentar reservar un grupo de 5 asientos consecutivos
            sala.ReservarAsientosGrupo(5);

            // Mostrar asientos después de intentar reservar un grupo más grande
            sala.MostrarAsientos();
        }
    }

}
