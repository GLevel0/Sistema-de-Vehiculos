using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3.VehicleTypes
{
    public class Motorcycle : Vehicle
    {
        public int EngineDisplacement { get; set; }

        public override decimal CalculateTax()
        {
            Tax = BasePrice * 0.15m;
            return Tax;
        }
    }
}
