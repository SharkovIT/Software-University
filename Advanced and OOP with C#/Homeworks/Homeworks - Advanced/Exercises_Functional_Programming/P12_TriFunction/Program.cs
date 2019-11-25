using System;
using System.Linq;

namespace P12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split();

            Func<string, int, bool> isLarger = (name, number) => name.Sum(x => x) >= sum;

            Func<string[], Func<string, int, bool>, string> nameFilter = (inputNames, isLargerFilter)
                => inputNames.FirstOrDefault(x => isLargerFilter(x, sum));

            string resultName = nameFilter(names, isLarger);
            Console.WriteLine(resultName);
        }
    }
}
