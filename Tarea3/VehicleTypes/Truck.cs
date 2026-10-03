using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3.VehicleTypes
{
    public class Truck : Vehicle
    {
        public decimal LoadCapacity { get; set; }

        public override decimal CalculateTax()
        {
            Tax = BasePrice * 0.30m;
            return Tax;
        }
    }
}
