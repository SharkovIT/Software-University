using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divisible = int.Parse(Console.ReadLine());

            Action<List<int>> printCollection = x => Console.WriteLine(string.Join(" ", x));

            Predicate<int> isDivisible = number => number % divisible != 0;

            collection = collection.Where(x => isDivisible(x)).ToList();

            printCollection(collection);
        }
    }
}
