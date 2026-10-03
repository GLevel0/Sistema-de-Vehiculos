using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3.VehicleTypes
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public override decimal CalculateTax()
        {
            Tax = BasePrice * 0.20m;
            return Tax;
        }
    }
}
