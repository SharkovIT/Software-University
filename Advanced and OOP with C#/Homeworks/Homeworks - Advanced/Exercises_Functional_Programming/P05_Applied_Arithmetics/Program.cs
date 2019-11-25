using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Func<int, int> addOne = x => x += 1;
            Func<int, int> multiply = x => x *= 2;
            Func<int, int> subtract = x => x -= 1;
            Action<List<int>> printNumbers = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addOne).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiply).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtract).ToList();
                }
                else if (command == "print")
                {
                    printNumbers(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
