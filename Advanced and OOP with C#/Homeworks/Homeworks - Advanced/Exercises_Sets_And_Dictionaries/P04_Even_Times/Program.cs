using System;
using System.Collections.Generic;

namespace P04_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenNumber = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!evenNumber.ContainsKey(input))
                {
                    evenNumber[input] = 1;
                }
                else
                {
                    evenNumber[input]++;
                }
            }
            foreach (var even in evenNumber)
            {
                if (even.Value % 2 == 0)
                {
                    Console.WriteLine(even.Key);
                }
            }
        }
    }
}
