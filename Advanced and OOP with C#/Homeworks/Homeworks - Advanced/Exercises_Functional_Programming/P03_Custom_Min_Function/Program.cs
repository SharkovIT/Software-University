using System;
using System.Linq;

namespace P03_Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Action<int> printNumber = number => Console.WriteLine(number);

            Func<int[], int> minFunc = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }
                return minValue;
            };

            int minNumber = minFunc(inputNumbers);
            printNumber(minNumber);
        }
    }
}
