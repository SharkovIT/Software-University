using System; 
using System.Collections.Generic;
using System.Linq;

namespace P04_Find_Even_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lowerBound = range[0];
            int upperBound = range[1];

            string command = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;

            Action<List<int>> printNumbers = outputNumbers 
                => Console.WriteLine(string.Join(" ", outputNumbers));

            if (command == "odd")
            {
               numbers = numbers.Where(x => isOdd(x)).ToList();
            }
            else
            {
                numbers = numbers.Where(x => isEven(x)).ToList();

            }

            printNumbers(numbers);
        }
    }
}
