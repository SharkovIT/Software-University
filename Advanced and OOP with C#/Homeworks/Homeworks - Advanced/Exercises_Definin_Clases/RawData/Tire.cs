using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        public double TirePressure { get; set; }
        public int Age { get; set; }

        public Tire(double pressure, int age)
        {
            TirePressure = pressure;
            Age = age;
        }
    }
}
