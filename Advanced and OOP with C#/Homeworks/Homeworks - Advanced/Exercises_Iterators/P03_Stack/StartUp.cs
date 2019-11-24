using System;
using System.Linq;

namespace P03_Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var data = new CustomStack<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input.Contains("Push"))
                {
                    var elements = input.Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                    foreach (var item in elements)
                    {
                        data.Push(item);
                    }
                }
                else
                {
                    data.Pop();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var value in data)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
