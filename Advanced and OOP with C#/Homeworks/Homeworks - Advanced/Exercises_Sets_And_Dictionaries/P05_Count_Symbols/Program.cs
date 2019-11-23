using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!counts.ContainsKey(input[i]))
                {
                    counts[input[i]] = 1;
                }
                else
                {
                    counts[input[i]]++;
                }
            }

            foreach (var count in counts.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{count.Key}: {count.Value} time/s");
            }
        }
    }
}
