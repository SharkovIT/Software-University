using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P04_Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());
            int[] orderQuantity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>(orderQuantity);

            Console.WriteLine($"{queue.Max()}");

            while (queue.Count != 0)
            {
                if (foodAmount >= queue.Peek() )
                {
                    foodAmount -= queue.Peek();
                    queue.Dequeue();
                }              
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
