using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car 
    {
        public string Model { get; set; }

        public Engine engine;
        public Cargo cargo;
        public List<Tire> tires = new List<Tire>();

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }
    }
}
