using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var quene = new Queue<int[]>();
           
            for (int i = 0; i < count; i++)
            {
               int[] petrolPump = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                quene.Enqueue(petrolPump);                               
            }
            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var petrolPump in quene)
                {
                    int amount = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += amount - distance;

                    if (totalFuel < 0)
                    {
                        quene.Enqueue(quene.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
