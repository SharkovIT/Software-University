using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int engineCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineCount; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                Engine engine = new Engine(model, power);

                if (engineData.Length == 3)
                {
                    if (int.TryParse(engineData[2], out int displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }
                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carsData[0];
                string engine = carsData[1];

                Engine engineModel = engines.FirstOrDefault(e => e.Model == engine);

                Car car = new Car(model, engineModel);

                if (carsData.Length == 3)
                {
                    if (int.TryParse(carsData[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carsData[2];
                    }
                }
                else if (carsData.Length == 4)
                {
                    car.Weight = int.Parse(carsData[2]);
                    car.Color = carsData[3];
                }
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
