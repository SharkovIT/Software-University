using System;

namespace P01_Action_Point
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
                    Console.WriteLine(name);
                }
            };

            printNames(inputNames);
        }
    }
}
