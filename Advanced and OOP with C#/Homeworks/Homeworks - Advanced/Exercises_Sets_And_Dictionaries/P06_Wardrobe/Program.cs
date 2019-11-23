using System;
using System.Collections.Generic;

namespace P06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");

                string colour = input[0];

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe[colour] = new Dictionary<string, int>();
                }

                string[] splittedInput = input[1].Split(",");

                foreach (var item in splittedInput)
                {
                    if (!wardrobe[colour].ContainsKey(item))
                    {
                        wardrobe[colour].Add(item, 0);
                    }

                    wardrobe[colour][item]++;
                }
            }

            string[] lookFor = Console.ReadLine().Split();

            foreach (var item in wardrobe)
            {
                var a = item.Value;
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var it in a)
                {
                    if (item.Key == lookFor[0] && it.Key == lookFor[1])
                    {
                        Console.WriteLine($"* {it.Key} - {it.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {it.Key} - {it.Value}");
                    }
                }
            }
        }
    }
}
