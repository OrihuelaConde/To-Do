using System;
using System.Collections.Generic;
using System.Linq;

namespace To_Do
{
    class Program
    {
        static void Main(string[] args)
        {
            string respuesta;
            List<Tarea> tareas = new List<Tarea>();

            do
            {
                Console.Clear();
                if(tareas.Any(t => t.Finalizada == false))
                {
                    Console.WriteLine("Hola, esta es tu lista de tareas\r\n");

                    foreach (Tarea tarea in tareas)
                    {
                        if (tarea.Finalizada == false)
                        {
                            Console.WriteLine($"{tarea.Id} - {tarea.Titulo}: {tarea.Contenido}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Hola, no tienes ninguna tarea pendiente");
                }

                Console.Write("\r\nIngrese 'n' para crear una nueva tarea, el número de la tarea para finalizarla o 's' para salir: ");
                respuesta = Console.ReadLine();
                if (int.TryParse(respuesta, out int result))
                {
                    Tarea tarea = tareas.Single(t => t.Id == result);
                    tarea.Finalizada = true;
                }
                else
                {
                    if (respuesta == "n")
                    {
                        Console.Clear();
                        Tarea tarea = new Tarea();
                        Console.Write("Ingrese el título de la tarea: ");
                        tarea.Titulo = Console.ReadLine();
                        Console.Write("Ingrese el contenido de la tarea: ");
                        tarea.Contenido = Console.ReadLine();
                        if(tareas.Any())
                        {
                            tarea.Id = tareas.Max(t => t.Id) + 1;
                        }
                        else
                        {
                            tarea.Id = 1;
                        }
                        tarea.Finalizada = false;
                        tareas.Add(tarea);
                    }
                    if (respuesta == "s")
                    {
                        Console.Write("\r\n¡Nos vemos!\r\n");
                    }
                }                
            } while (respuesta != "s");
        }
    }
}
