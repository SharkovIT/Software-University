using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>(numbers);

            for (int i = 0; i < commands[1]; i++)
            {
               queue.Dequeue();
            }            
            if (queue.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{queue.Min()}");
            }
        }
    }
}
