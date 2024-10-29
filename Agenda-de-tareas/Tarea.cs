using System;
using System.Collections;
using System.Collections.Generic;

namespace Agenda_de_tareas
{
    internal class Tarea
    {
        private string titulo { get; set; }
        private bool completada { get; set; }

        private static List<Tarea> agenda = new List<Tarea>();  // Lista estática de tareas

        public Tarea(string titulo, bool completada)
        {
            this.titulo = titulo;
            this.completada = completada;
        }

        public static void AgregarTarea(Tarea tarea)
        {
            agenda.Add(tarea);
        }

        public static void EliminarTarea(string titulo)
        {
            Tarea tareaAEliminar = agenda.Find(t => t.titulo == titulo);
            if (tareaAEliminar != null)
            {
                agenda.Remove(tareaAEliminar);
                Console.WriteLine($"La tarea '{titulo}' ha sido eliminada.");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con el título '{titulo}'.");
            }
        }

        public static void MarcarCompletada(string titulo)
        {
            Tarea tareaACompletar = agenda.Find(t => t.titulo == titulo);
            if (tareaACompletar != null)
            {
                tareaACompletar.completada = true;
                Console.WriteLine($"La tarea '{titulo}' ha sido marcada como completada.");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con el título '{titulo}'.");
            }
        }

        // Método para mostrar todas las tareas
        public static void MostrarTareas()
        {
            if (agenda.Count == 0)
            {
                Console.WriteLine("No hay tareas en la agenda.");
                return;
            }

            Console.WriteLine("Lista de tareas:");
            foreach (var tarea in agenda)
            {
                string estado = tarea.completada ? "Completada" : "Pendiente";
                Console.WriteLine($"- {tarea.titulo} [{estado}]");
            }
        }

        // Método para mostrar el estado de una tarea específica
        public static void MostrarEstadoTarea(string titulo)
        {
            Tarea tarea = agenda.Find(t => t.titulo == titulo);
            if (tarea != null)
            {
                string estado = tarea.completada ? "Completada" : "Pendiente";
                Console.WriteLine($"La tarea '{titulo}' está: {estado}");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con el título '{titulo}'.");
            }
        }

        public static string Menu()
        {
            string toReturn = "-------------------------------------------" +
                              "\nElige una operación:" +
                              "\n1. Crear y agregar una tarea" +
                              "\n2. Eliminar una tarea por su título" +
                              "\n3. Marcar tarea como completada" +
                              "\n4. Mostrar tareas por pantalla" +
                              "\n5. Mostrar estado de una tarea" +
                              "\n0. Salir\n";
            return toReturn;
        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(Menu());
                Console.WriteLine("Selecciona una operación: ");
                int select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        Console.WriteLine("Introduzca el título de la tarea:");
                        string titulo = Console.ReadLine();
                        Tarea nuevaTarea = new Tarea(titulo, false);
                        AgregarTarea(nuevaTarea);
                        Console.WriteLine($"Se ha agregado la tarea '{titulo}'.");
                        break;

                    case 2:
                        Console.WriteLine("Introduce el título de la tarea a eliminar:");
                        string tituloEliminar = Console.ReadLine();
                        EliminarTarea(tituloEliminar);
                        break;

                    case 3:
                        Console.WriteLine("Introduce el título de la tarea a marcar como completada:");
                        string tituloCompletar = Console.ReadLine();
                        MarcarCompletada(tituloCompletar);
                        break;

                    case 4:
                        MostrarTareas();
                        break;

                    case 5:
                        Console.WriteLine("Introduce el título de la tarea para ver su estado:");
                        string tituloEstado = Console.ReadLine();
                        MostrarEstadoTarea(tituloEstado);
                        break;

                    case 0:
                        exit = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Operación no válida, por favor inténtalo de nuevo.");
                        break;
                }
            }
        }
    }
}
