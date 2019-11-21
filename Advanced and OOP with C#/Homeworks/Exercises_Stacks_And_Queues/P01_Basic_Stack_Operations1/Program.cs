using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Basic_Stack_Operations1
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

            var stack = new Stack<int>(numbers);

            for (int i = 0; i < commands[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{stack.Min()}");
            }

        }
    }
}
