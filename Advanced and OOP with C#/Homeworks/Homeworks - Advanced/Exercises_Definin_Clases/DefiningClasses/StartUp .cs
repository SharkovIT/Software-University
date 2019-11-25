using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();

                string model = data[1];
                double amountOfKm = double.Parse(data[2]);

                Car car = cars.FirstOrDefault(c => c.Model == model);
                car.Drive(amountOfKm);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
