using System;
using System.Collections.Generic;
using System.Linq;
using Tarea3;
using Tarea3.VehicleTypes;

namespace Tarea3
{
    public class VehicleSystem
    {
        public static void CaptureData(Vehicle vehicle)
        {
            Console.Write("Ingrese la marca: ");
            vehicle.Brand = Console.ReadLine() ?? "";

            Console.Write("Ingrese el modelo: ");
            vehicle.Model = Console.ReadLine() ?? "";

            Console.Write("Ingrese el año: ");
            vehicle.Year = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese el precio base: ");
            vehicle.BasePrice = decimal.Parse(Console.ReadLine() ?? "0");

            if (vehicle is Car car)
            {
                Console.Write("Ingrese el número de puertas: ");
                car.NumberOfDoors = int.Parse(Console.ReadLine() ?? "0");
            }
            else if (vehicle is Truck truck)
            {
                Console.Write("Ingrese la capacidad de carga en toneladas: ");
                truck.LoadCapacity = decimal.Parse(Console.ReadLine() ?? "0");
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                Console.Write("Ingrese la cilindrada en cc: ");
                motorcycle.EngineDisplacement = int.Parse(Console.ReadLine() ?? "0");
            }
            else if (vehicle is Bus bus)
            {
                Console.Write("Ingrese la capacidad de pasajeros: ");
                bus.PassengerCapacity = int.Parse(Console.ReadLine() ?? "0");
            }

            vehicle.CalculateTax();
        }

        public static void DisplayVehicle(Vehicle vehicle)
        {
            Console.WriteLine("\n--- INFORMACIÓN DEL VEHÍCULO ---");
            Console.WriteLine($"Tipo: {GetVehicleType(vehicle)}");
            Console.WriteLine($"Marca: {vehicle.Brand}");
            Console.WriteLine($"Modelo: {vehicle.Model}");
            Console.WriteLine($"Año: {vehicle.Year}");
            Console.WriteLine($"Precio base: {vehicle.BasePrice:C2}");
            Console.WriteLine($"Impuesto aplicado: {vehicle.Tax:C2}");
            Console.WriteLine($"Precio de venta: {vehicle.SalePrice:C2}");

            if (vehicle is Car car)
            {
                Console.WriteLine($"Número de puertas: {car.NumberOfDoors}");
            }
            else if (vehicle is Truck truck)
            {
                Console.WriteLine($"Capacidad de carga: {truck.LoadCapacity} toneladas");
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                Console.WriteLine($"Cilindrada: {motorcycle.EngineDisplacement} cc");
            }
            else if (vehicle is Bus bus)
            {
                Console.WriteLine($"Capacidad de pasajeros: {bus.PassengerCapacity}");
            }
        }

        public static void DisplayVehicles(List<Vehicle> vehicles)
        {
            Console.Clear();
            Console.WriteLine("===== VEHÍCULOS REGISTRADOS =====");

            if (vehicles.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"\nVehículo #{i + 1}");
                DisplayVehicle(vehicles[i]);
            }

            Console.WriteLine($"\nTotal de vehículos registrados: {vehicles.Count}");
        }

        public static void DisplaySummary(List<Vehicle> vehicles)
        {
            Console.Clear();
            Console.WriteLine("===== RESUMEN FINANCIERO =====");

            decimal totalBasePrice = vehicles.Sum(v => v.BasePrice);
            decimal totalTax = vehicles.Sum(v => v.Tax);
            decimal totalSalePrice = vehicles.Sum(v => v.SalePrice);

            Console.WriteLine($"Total de vehículos: {vehicles.Count}");
            Console.WriteLine($"Precio base total: {totalBasePrice:C2}");
            Console.WriteLine($"Total de impuestos: {totalTax:C2}");
            Console.WriteLine($"Precio total de venta: {totalSalePrice:C2}");

            Console.WriteLine("\n===== CANTIDAD POR TIPO =====");
            Console.WriteLine($"Carros: {vehicles.Count(v => v is Car)}");
            Console.WriteLine($"Camiones: {vehicles.Count(v => v is Truck)}");
            Console.WriteLine($"Motocicletas: {vehicles.Count(v => v is Motorcycle)}");
            Console.WriteLine($"Autobuses: {vehicles.Count(v => v is Bus)}");
        }

        public static string GetVehicleType(Vehicle vehicle)
        {
            if (vehicle is Car)
                return "Carro";

            if (vehicle is Truck)
                return "Camión";

            if (vehicle is Motorcycle)
                return "Motocicleta";

            if (vehicle is Bus)
                return "Autobús";

            return "Desconocido";
        }
    }
}