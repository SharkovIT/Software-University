using System;

namespace P02_Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split();

            Action<string[]> printNames = names =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            printNames(inputNames);
        }
    }
}
