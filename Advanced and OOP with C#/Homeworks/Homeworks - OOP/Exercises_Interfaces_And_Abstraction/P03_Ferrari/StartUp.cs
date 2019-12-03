using System;

namespace P03_Ferrari
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
