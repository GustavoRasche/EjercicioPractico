using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPractico
{
    class Program

    {
        static void Main(string[] args)
        {
            List<Eliminador> eliminadores = new List<Eliminador>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido a SkyNet\n");
                Console.WriteLine("1. Ingresar Eliminador");
                Console.WriteLine("2. Buscar Eliminador");
                Console.WriteLine("3. Mostrar Eliminador");
                Console.WriteLine("4. Destruir SkyNet");
                Console.WriteLine("5. Salir\n");
                Console.Write("Ingrese la opción deseada: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresarEliminador(eliminadores);
                        break;

                    case "2":
                        BuscarEliminador(eliminadores);
                        break;

                    case "3":
                        MostrarEliminadores(eliminadores);
                        break;

                    case "4":
                        DestruirSkyNet(eliminadores);
                        break;

                    case "5":
                        Console.WriteLine("\nHasta luego!\n");
                        return;

                    default:
                        Console.WriteLine("\nOpción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void IngresarEliminador(List<Eliminador> eliminadores)
        {
            Eliminador nuevoEliminador = new Eliminador();
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine("Ingrese el número de serie (7 caracteres): ");
                string numeroSerie = Console.ReadLine();
                if (numeroSerie.Length != 7)
                {
                    Console.WriteLine("El número de serie debe tener 7 caracteres.");
                    continue;
                }
                nuevoEliminador.NumeroSerie = numeroSerie;

                Console.WriteLine("Ingrese el tipo de eliminador (T-1, T-800, T-1000 o T-3000): ");
                string tipo = Console.ReadLine();
                if (tipo != "T-1" && tipo != "T-800" && tipo != "T-1000" && tipo != "T-3000")
                {
                    Console.WriteLine("Tipo de eliminador inválido.");
                    continue;
                }
                nuevoEliminador.Tipo = tipo;

                Console.WriteLine("Ingrese la prioridad base (1-5): ");
                int prioridad;
                if (!int.TryParse(Console.ReadLine(), out prioridad) || prioridad < 1 || prioridad > 5)
                {
                    Console.WriteLine("Prioridad base inválida.");
                    continue;
                }
                nuevoEliminador.PrioridadBase = prioridad;

                Console.WriteLine("Ingrese el objetivo: ");
                string objetivo = Console.ReadLine();
                nuevoEliminador.Objetivo = objetivo;

                Console.WriteLine("Ingrese el año de destino (mayor que 1997 y menor que 3000): ");
                int ano;
                if (!int.TryParse(Console.ReadLine(), out ano) || ano <= 1997 || ano >= 3000)
                {
                    Console.WriteLine("Año de destino inválido.");
                    continue;
                }
                nuevoEliminador.AnoDestino = ano;

                valido = true;
            }
            eliminadores.Add(nuevoEliminador);
        }

        public static void BuscarEliminador(List<Eliminador> eliminadores)
        {
            Console.WriteLine("Ingrese el modelo de Eliminador a buscar:");
            string tipo = Console.ReadLine();

            Console.WriteLine("Ingrese el año de destino del Eliminador a buscar:");
            int año = Convert.ToInt32(Console.ReadLine());

            var eliminadoresEncontrados = eliminadores.Where(e => e.Tipo == tipo && e.AnoDestino == año);

            if (eliminadoresEncontrados.Count() == 0)
            {
                Console.WriteLine("No se encontraron Eliminadores con los criterios de búsqueda ingresados.");
            }
            else
            {
                Console.WriteLine("Eliminadores encontrados:");
                foreach (Eliminador eliminador in eliminadoresEncontrados)
                {
                    Console.WriteLine($"Eliminador encontrado: {eliminador.Tipo} - Año: {eliminador.AnoDestino}");
                }
            }
        }


        public static void MostrarEliminadores(List<Eliminador> eliminadores)
        {
            Console.WriteLine("Listado de Eliminadores:\n");
            foreach (Eliminador eliminador in eliminadores)
            {
                Console.WriteLine("{0} {1} {2}", eliminador.NumeroSerie, eliminador.Tipo, eliminador.Objetivo);
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void DestruirSkyNet(List<Eliminador> eliminadores)
        {
            eliminadores.Clear();
            Console.WriteLine("SkyNet ha sido destruido.\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}