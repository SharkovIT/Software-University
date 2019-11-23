using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()
                     .Split()
                     .ToList();

                for (int j = 0; j < input.Count; j++)
                {
                    chemicalElements.Add(input[j]);
                }
            }

            foreach (var element in chemicalElements)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
