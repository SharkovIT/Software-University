using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carNames = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];

                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);

                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];

                double tirePressure1 = double.Parse(carData[5]);
                int tireAge1 = int.Parse(carData[6]);

                double tirePressure2 = double.Parse(carData[7]);
                int tireAge2 = int.Parse(carData[8]);

                double tirePressure3 = double.Parse(carData[9]);
                int tireAge3 = int.Parse(carData[10]);

                double tirePressure4 = double.Parse(carData[11]);
                int tireAge4 = int.Parse(carData[12]);

                Car car = new Car(model, 
                    new Engine(engineSpeed, enginePower), 
                    new Cargo(cargoWeight, cargoType), 
                    new List<Tire> {new Tire(tirePressure1, tireAge1), new Tire(tirePressure2, tireAge2), new Tire(tirePressure3, tireAge3), new Tire(tirePressure4, tireAge4) });

                carNames.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                carNames = carNames.Where(x => x.cargo.CargoType == "fragile").Where(t => t.tires.Any(x => x.TirePressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
                carNames = carNames.Where(x => x.cargo.CargoType == "flamable").Where(e => e.engine.EnginePower > 250).ToList();
            }

            foreach (Car car in carNames)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
