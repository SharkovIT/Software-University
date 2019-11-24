using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listy = null;

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    if (command.Contains("Create"))
                    {
                        List<string> items = command.Split().Skip(1).ToList();
                        listy = new ListyIterator<string>(items);
                    }
                    else if (command == "Print")
                    {
                        listy.Print();
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listy.HasNext());
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(listy.Move());
                    }
                    else if (command == "PrintAll")
                    {
                        foreach (var item in listy)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

        }
    }
}
