using System;
using System.Linq;

namespace GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Add(input);
            }

            double comparer = double.Parse(Console.ReadLine());

            box.Compare(box.boxCollection, comparer);

            Console.WriteLine(box.Count);

        }
    }
}
