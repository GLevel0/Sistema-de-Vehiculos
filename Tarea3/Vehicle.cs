using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3
{
        public abstract class Vehicle
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public decimal BasePrice { get; set; }
            public decimal Tax { get; protected set; }

            public decimal SalePrice
            {
                get { return BasePrice + Tax; }
            }

            public abstract decimal CalculateTax();
        }
}
