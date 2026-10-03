using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3.VehicleTypes
{
    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }

        public override decimal CalculateTax()
        {
            Tax = BasePrice * 0.25m;
            return Tax;
        }
    }
}
