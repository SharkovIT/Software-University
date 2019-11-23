using System;
using System.Collections.Generic;

namespace P06_Auto_Repair_And_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = Console.ReadLine().Split();
            var queue = new Queue<string>(cars);
            var servedCars = new Stack<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input == "Service")
                {
                    if (queue.Count == 0)
                    {
                        continue;
                    }
                    servedCars.Push(queue.Peek());
                    Console.WriteLine($"Vehicle {queue.Dequeue()} got served.");
                    continue;
                }
                else if (input == "History")
                {
                    Console.WriteLine($"{string.Join(", ",servedCars)}");
                }
                else
                {
                    string carName = input.Split("-")[1];

                    if (!queue.Contains(carName))
                    {
                        Console.WriteLine("Served.");
                    }
                    else
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }
            }
            if (queue.Count != 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queue)}");
            }
            
            Console.WriteLine($"Served vehicles: {string.Join(", ",servedCars)}");
        }
    }
}
