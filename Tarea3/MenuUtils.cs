using System;
using System.Collections.Generic;
using Tarea3;
using Tarea3.VehicleTypes;

namespace Tarea3
{
    public class MenuUtils
    {
        private static readonly List<Vehicle> vehicles = new List<Vehicle>();

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("===== SISTEMA DE REGISTRO DE VEHÍCULOS =====");
            Console.WriteLine("1. Registrar vehículo");
            Console.WriteLine("2. Ver vehículos registrados");
            Console.WriteLine("3. Ver resumen financiero");
            Console.WriteLine("4. Salir del sistema");
            Console.Write("Seleccione una opción: ");
        }

        public static Vehicle SelectVehicleType()
        {
            Console.Clear();
            Console.WriteLine("===== SELECCIONE EL TIPO DE VEHÍCULO =====");
            Console.WriteLine("1. Carro");
            Console.WriteLine("2. Camión");
            Console.WriteLine("3. Motocicleta");
            Console.WriteLine("4. Autobús");
            Console.WriteLine("5. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int type))
            {
                Console.WriteLine("Opción inválida.");
                Pause();
                return null;
            }

            switch (type)
            {
                case 1:
                    return new Car();

                case 2:
                    return new Truck();

                case 3:
                    return new Motorcycle();

                case 4:
                    return new Bus();

                default:
                    return null;
            }
        }

        public static void RegisterVehicle()
        {
            Vehicle vehicle = SelectVehicleType();

            if (vehicle == null)
            {
                return;
            }

            Console.Clear();
            VehicleSystem.CaptureData(vehicle);

            vehicles.Add(vehicle);

            Console.Clear();
            Console.WriteLine("¡Vehículo registrado correctamente!");
            VehicleSystem.DisplayVehicle(vehicle);

            Pause();
        }

        public static void ViewVehicles()
        {
            VehicleSystem.DisplayVehicles(vehicles);
            Pause();
        }

        public static void ViewSummary()
        {
            VehicleSystem.DisplaySummary(vehicles);
            Pause();
        }

        public static void Pause()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void HandleOption(int option)
        {
            switch (option)
            {
                case 1:
                    RegisterVehicle();
                    break;

                case 2:
                    ViewVehicles();
                    break;

                case 3:
                    ViewSummary();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Pause();
                    break;
            }
        }

        public static void RunMenu()
        {
            int option = 0;

            while (option != 4)
            {
                ShowMainMenu();

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Opción inválida.");
                    Pause();
                    continue;
                }

                HandleOption(option);
            }
        }
    }
}