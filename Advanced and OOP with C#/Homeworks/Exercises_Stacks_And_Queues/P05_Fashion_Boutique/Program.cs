using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            int count = 0;
            int sum = 0;

            var stack = new Stack<int>(clothes);

            while (stack.Count != 0)
            {
                int currentNumber = stack.Peek();
                sum += currentNumber;

                if (sum > capacity)
                {
                    count++;
                    sum = 0;
                    continue;
                }
                if (stack.Count == 1 && sum < capacity)
                {
                    count++;
                }

                stack.Pop();

                if (sum == capacity)
                {
                    count++;
                    sum = 0;
                }
            }
            Console.WriteLine(count);
        }
    }
}
