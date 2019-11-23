using System;
using System.Collections.Generic;
using System.Linq;

namespace P12_Cups_And_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cupSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] bottleSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> cupCapacity = new Queue<int>(cupSequence);
            Stack<int> bottleCapacity = new Stack<int>(bottleSequence);

            int wastedWater = 0;

            while (cupCapacity.Any() && bottleCapacity.Any())
            {
                int cup = cupCapacity.Peek();
                int bottle = bottleCapacity.Peek();

                if (bottle >= cup)
                {
                    cupCapacity.Dequeue();
                    bottleCapacity.Pop();
                    wastedWater += bottle - cup;
                    cupSequence.RemoveAt(0);
                }
                else
                {
                    int remainingCup = Math.Abs(bottle - cup);
                    cupSequence.RemoveAt(0);
                    cupSequence.Insert(0, remainingCup);
                    cupCapacity = new Queue<int>(cupSequence);
                    bottleCapacity.Pop();
                }
            }
            if(bottleCapacity.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleCapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupCapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
