using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());

            List<int> numbers = Enumerable.Range(1, upperBound).ToList();

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            for (int i = 0; i < dividers.Length; i++)
            {
                Predicate<int> divisible = num =>
                {
                    return num % dividers[i] == 0;
                };
                numbers = numbers.FindAll(divisible);
            }
           
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
