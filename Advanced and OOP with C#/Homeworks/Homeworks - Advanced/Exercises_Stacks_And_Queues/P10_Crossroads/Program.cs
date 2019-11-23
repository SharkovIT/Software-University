using System;
using System.Collections.Generic;

namespace P10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            bool isHitted = false;
            string hittedCarName = string.Empty;
            char hittedSymbol = '\0';
            int totalCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }              

                if (input != "green")
                {
                    queue.Enqueue(input);
                    continue;
                }

                int currentGreenLightDuration = greenLightDuration;

                while (currentGreenLightDuration > 0 && queue.Count > 0)
                {
                    string carName = queue.Dequeue();
                    int carLenght = carName.Length;

                    if (currentGreenLightDuration - carLenght >= 0)
                    {
                        currentGreenLightDuration -= carLenght;
                        totalCars++;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;

                        if (currentGreenLightDuration - carLenght >= 0)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCarName = carName;
                            hittedSymbol = carName[currentGreenLightDuration];
                            break;
                        }
                    
                    }
                }
                if (isHitted)
                {
                    break;
                }                
            }
            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
