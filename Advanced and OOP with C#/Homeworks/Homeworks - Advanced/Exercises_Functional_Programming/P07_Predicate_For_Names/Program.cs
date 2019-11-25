using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine()
                .Split();

            Predicate<string> isLengthLessOrEqual = x 
                => x.Length <= length;

            Action<string[]> printNames = x 
                => Console.WriteLine(string.Join(Environment.NewLine, x));

            inputNames = inputNames
                .Where(x => isLengthLessOrEqual(x))
                .ToArray();

            printNames(inputNames);
        }
    }
}
